<?php
define('TITLE', 'Archivo no encontrado.');
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
    <h2>Lo sentimos, el archivo al que deseas acceder parece no existir.</h2>
    <img src="../../assets/img/post/404.png" alt="Chems404">
</body>
<footer>
    <?php include '../../assets/dependencies/foot.php' ?>
</footer>

</html>