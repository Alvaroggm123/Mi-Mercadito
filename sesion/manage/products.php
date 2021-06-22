<?php
define('TITLE', 'Administrador de usuarios - AxolotlTeam');
include_once '../../assets/dependencies/connection.php';
session_start();

if (!isset($_SESSION['rol'])) {
    header('location: ../../login.php');
} else {
    if ($_SESSION['rol'] == 6 || $_SESSION['rol'] == 5) {
    } else
        header('location: ../login.php');
}

if (!isset($_SESSION['rol'])) {
    header('location: ../../login.php');
} else {
    if ($_SESSION['rol'] == 6 || $_SESSION['rol'] == 5) {
    } else
        header('location: ../login.php');
}
if (isset($_GET['delUser'])) {
    $flag = false;
    $db = new Database();
    $flag = $db->EliminarUsuario($_GET['delUser']);
    if ($flag)
        AlertMessage('Usuario eliminado correctamente', "");
    else
        AlertMessage('No se realizaron modificaciones.', "");
}
if (isset($_POST['modId']) && (isset($_POST['modUsername']) || isset($_POST['modFname']) || isset($_POST['modLname']) || isset($_POST['modEmail']) || isset($_POST['modPassword']))) {
    $db = new Database();
    $flag = false;
    if ($_POST['modUsername'] != "")
        $flag = $db->ModificarUsuario($_POST['modId'], 'usrUsername', $_POST['modUsername']);
    if ($_POST['modFname'] != "")
        $flag = $db->ModificarUsuario($_POST['modId'], 'usrFname', $_POST['modFname']);
    if ($_POST['modLname'] != "")
        $flag = $db->ModificarUsuario($_POST['modId'], 'usrLname', $_POST['modLname']);
    if ($_POST['modEmail'] != "")
        $flag = $db->ModificarUsuario($_POST['modId'], 'usrEmail', $_POST['modEmail']);
    if ($_POST['modPassword'] != "") {
        $Password = password_hash($_POST['modPassword'], PASSWORD_DEFAULT);
        $flag = $db->ModificarUsuario($_POST['modId'], 'usrPassword', $Password);
    }
    //header('location: users.php');
    if ($flag)
        AlertMessage('Usuario modificado correctamente', "");
    else
        AlertMessage('No se realizaron modificaciones.', "");
}

?>
<!DOCTYPE HTML>
<html lang="es-mx">

<head>
    <?php include '../../assets/dependencies/head.php' ?>
    <link rel="shortcut icon" href="../../assets/img/icon/favicon.ico" />
    <title><?php echo TITLE; ?></title>

</head>
<header>
    <?php include '../../assets/dependencies/navbar.php' ?>
</header>

<body>
    <h1>AxolotlTeam</h1>
    <h2>Bienvenido al administrador de usuarios, recuerda que los movimientos están siendo registrados.</h2>

    <table class='table table-striped'>
        <thead>
            <th scope="row">ID.</th>
            <th>Nombre de usuario</th>
            <th>Nombre</th>
            <th>Apellido(s)</th>
            <th>E-mail</th>
            <th>Contraseña</th>
            <th>Administrar</th>
        </thead>
        <?php
        $db = new Database();
        $db->getUsers();
        ?>
    </table>
</body>
<footer>
    <?php include '../../assets/dependencies/foot.php' ?>
</footer>

</html>