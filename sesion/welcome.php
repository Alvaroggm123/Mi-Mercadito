<?php
define('TITLE', 'Fundador - AxolotlTeam');
include_once '../assets/dependencies/connection.php';
session_start();

if (!isset($_SESSION['rol']))
    header('location: login.php');
?>
<!DOCTYPE HTML>
<html lang="es-mx">

<head>
    <?php include '../assets/dependencies/head.php' ?>
    <link rel="shortcut icon" href="../assets/img/icon/favicon.ico" />
    <title><?php echo TITLE; ?></title>

</head>
<header>
    <?php include '../assets/dependencies/navbar.php' ?>
</header>

<body>
<div class="container">
    <h1>AxolotlTeam</h1>
    <h2><?php 
        switch($_SESSION['usrSex']){
            case "M":
                echo "Bienvenido ".$_SESSION['usrUsername'];
                break;
            case "F":
                echo "Bienvenida ".$_SESSION['usrUsername'];
                break;
            default:
                echo "Hola ".$_SESSION['usrUsername'];
                break;
        }?>
    </h2>
    <div class="container">
        <div class="row">
            <div class="col-sm">
                One of three columns
            </div>
        <div class="col-lg">
            xd
        </div>
            <div class="col-sm">
                One of three columns
            </div>
        </div>
    </div>
</div>
</body>
<footer>
    <?php include '../assets/dependencies/foot.php' ?>
</footer>

</html>