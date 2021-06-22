<?php
define('TITLE', 'No es posible acceder');
include_once '../../assets/dependencies/connection.php';
session_start();
?>
<!DOCTYPE HTML>
<html lang="es-mx">

<head>
    <?php include '../../assets/dependencies/head.php' ?>
    <link rel="shortcut icon" href="../../assets/img/icon/favicon.ico" />
    <title>
        <?php echo TITLE; ?>
    </title>
</head>
<header>
    <?php include '../../assets/dependencies/navbar.php' ?>
</header>

<body>
    <h1>AxolotlTeam</h1>
    <h2>Lo sentimos, no es posible acceder al directorio.</h2>
    <img src="../../assets/img/post/404.png" alt="Chems404">
</body>
<footer>
    <?php include '../../assets/dependencies/foot.php' ?>
</footer>

</html>