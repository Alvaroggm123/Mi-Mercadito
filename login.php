<?php
define('TITLE', 'Inicio - AxolotlTeam');
include_once 'assets/dependencies/connection.php';
session_start();
if (isset($_GET['signOut'])) {
    session_unset();
    session_destroy();
    header('location: login.php');
}
if (isset($_SESSION['rol'])) {
    switch ($_SESSION['rol']) {
        case 1:
            header('location: sesion\welcome.php');
            break;
        default:
            header('location: sesion\welcome.php');
            break;
    }
}
if (isset($_POST['usrUsername']) && isset($_POST['usrPassword'])) {
    $usrUsername = $_POST['usrUsername'];
    $usrPassword = $_POST['usrPassword'];

    $db = new Database();
    $hash = $db->getHash($usrUsername);

    $verify = password_verify($usrPassword, $hash);

    $sql = 'SELECT * FROM Users WHERE usrUsername = ? AND usrPassword = ?;';
    $params = array($usrUsername, $hash);

    $conn = $db->connect();
    $stmt = sqlsrv_query($conn, $sql, $params);
    $row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC);

    if ($row == true && $verify == true) {
        $rol = $row['rolId'];
        $usrSex = $row['usrSex'];
        $_SESSION['rol'] = $rol;
        $_SESSION['usrUsername'] = $usrUsername;
        $_SESSION['usrSex'] = $usrSex;
        switch ($rol) {
            case 1:
                header('location: sesion\welcome.php');
                break;
            default:
                header('location: login.php');
                break;
        }
    } else {
        // no existe el usuario
        AlertMessage('Nombre de usuario o contraseña incorrecto','');
    }
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

<body>
    <h1>Iniciar sesión</h1>
    <table>
        <form action="#" method="post">
            <tr>
                <td><label>Usuario: </label></td>
                <td><input class="form-control" type="text" name="usrUsername" placeholder="Ingrese usuario" required=""></td>
            </tr>
            <tr>
                <td><label>Contraseña: </label></td>
                <td><input class="form-control" type="password" name="usrPassword" placeholder="Contraseña" required=""></td>
            </tr>
            <td><button class="btn btn-primary" id="sendMessageButton" type="submit">Iniciar sesión</button></td>
        </form>
        <form action='registration.php' method="post">
            <td><button class="btn btn-success" id="registrationForm" type="submit">Registrarme</button></td>
        </form>
    </table>

</body>
<footer>
    <?php include 'assets/dependencies/foot.php' ?>
</footer>

</html>