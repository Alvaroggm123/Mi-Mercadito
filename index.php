<?php
define('TITLE', 'Inicio - Mi mercadito');
include_once 'assets/dependencies/connection.php';
session_start();
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
    <h1>Mi mercadito</h1>
    
    <h2>Inicia sesión para poder comenzar a registrar tus productos.</h2>
</body>
<footer>
    <?php include 'assets/dependencies/foot.php' ?>
</footer>

</html>