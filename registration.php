<?php
define('TITLE', 'Registro - AxolotlTeam');
include_once 'assets/dependencies/connection.php';
session_start();
if (isset($_SESSION['rol'])) {
    header('location: sesion/welcome.php');
}
if (isset($_POST['usrUsername']) && isset($_POST['usrPassword'])&&isset($_POST['chkboxTerms'])) {
    $usrUsername    = $_POST['usrUsername'];
    $usrFname       = $_POST['usrFname'];
    $usrLname       = $_POST['usrLname'];
    $usrBirth       = $_POST['usrBdate'];
    $usrSex         = $_POST['rbtnGender'];
    $usrEmail       = $_POST['usrEmail'];
    $usrPassword    = password_hash($_POST['usrPassword'], PASSWORD_DEFAULT);
    $usrRegDate     = date("Y-m-d");
    $rolId          = 1;
    $terms          = $_POST['chkboxTerms'];

    $db = new Database();

    $sql = 'INSERT INTO Users(usrUsername, usrFname, usrLname, usrBirth, usrSex, usrEmail, usrPassword, usrRegDate, rolId) 
    VALUES (?,?,?,?,?,?,?,?,?)';
    $params = array($usrUsername, $usrFname, $usrLname, $usrBirth, $usrSex, $usrEmail, $usrPassword, $usrRegDate, $rolId);

    $conn = $db->connect();
    if ($terms == true) {
        $stmt = sqlsrv_query($conn, $sql, $params);
        if ($stmt === false)
            AlertMessage('Datos ingresados no validos.', "");
        //die(print_r(sqlsrv_errors(), true));
        else
            AlertMessage('Usuario registrado correctamente, favor de loguearse.', '');
    } else
        AlertMessage('Debe aceptar los terminos y condiciones.', '');
}
?>
<!DOCTYPE HTML>
<html lang="es-mx">

<head>
    <?php include 'assets/dependencies/head.php' ?>
    <link rel="shortcut icon" href="assets/img/icon/favicon.ico" />
    <title><?php echo TITLE; ?></title>
</head>
<header>
    <?php include 'assets/dependencies/navbar.php' ?>
</header>

<body onload="disableSubmit()">
    <h1>Registro de usuario</h1>
    <form method="POST" action="#">
        <table>
            <tr>
                <td> Nombre(s): </td>
                <td>
                    <input class="form-control" type="text" id="txtusrNombre" name="usrFname" required="" placeholder="Ingrese nombre">
                </td>
            </tr>
            <tr>
                <td> Apellido(s): </td>
                <td>
                    <input class="form-control" type="text" id="txtusrApellidos" name="usrLname" required="" placeholder="Ingrese apellidos">
                </td>
            </tr>
            <tr>
                <td> Correo electrónico: </td>
                <td>
                    <input class="form-control" type="email" id="txtusrCorreo" name="usrEmail" required="" placeholder="Ingrese Correo electrónico">
                </td>
            </tr>
            <tr>
                <td> Fecha de nacimiento: </td>
                <td>
                    <input class="form-control list-inline-item" name="usrBdate" type="date">
                </td>
            </tr>
            <tr>
                <td> Sexo: </td>
                <td>
                    <div class="list-inline-item">
                        <input type="radio" id="M" name="rbtnGender" value="M" required><label for="M"> Masculino </label>
                        <input type="radio" id="F" name="rbtnGender" value="F" required><label for="F"> Femenino </label>
                        <input type="radio" id="O" name="rbtnGender" value="O" required><label for="O"> Otro </label>
                    </div>
                </td>
            </tr>
        </table>
        <br>
        <table>
            <tr>
                <td> Nombre del usuario: </td>
                <td>
                    <input class="form-control" type="username" id="txtusrNomUsr" name="usrUsername" required="" placeholder="Ingrese usuario">
                </td>
            </tr>
            <tr>
                <td> Contraseña: </td>
                <td>
                    <input class="form-control" type="password" id="txtusrContrasena" name="usrPassword" required="" placeholder="Ingrese contraseña">
                </td>
            </tr>
            <tr>
                <td> Repetir contraseña: </td>
                <td>
                    <input class="form-control" type="password" id="txtusrContrasena2" placeholder="Ingrese contraseña">
                </td>
            </tr>
        </table>
        <br>
        <label><input type="checkbox" name="chkboxTerms" value="chkboxTerms" onchange="activateButton(this)"> Acepto los términos y condiciones.</label>
        <br><br>
        <table>
            <tr>
                <td colspan="2">
                    <div id="success"></div>
                <td>
                    <div class="form-group"><button class="btn btn-primary" id="submit" type="submit" name="submit">Aceptar</button></div>
                </td>
                <a href="index.php">
                    <div id="cancel"></div>
                    <td>
                        <a href="login.php">
                            <div class="form-group"><button class="btn btn-danger" id="sendMessageButton" type="button">Cancelar</button>
                        </a>
                    </td>
                </a>
                </td>
            </tr>
        </table>
    </form>

</body>
<footer>
    <?php include 'assets/dependencies/foot.php' ?>
</footer>

</html>