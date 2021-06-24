<?php
define('TITLE', 'Mi mercadito');
include_once '../assets/dependencies/connection.php';
session_start();

if (!isset($_SESSION['rol']))
    header('location: login.php');
function saludoSexo($sexo){
    switch($sexo){
    case "M":
        echo "Bienvenido ".$_SESSION['usrUsername'];
        break;
    case "F":
        echo "Bienvenida ".$_SESSION['usrUsername'];
        break;
    default:
        echo "Hola ".$_SESSION['usrUsername'];
        break;
    }}
if (isset($_GET['delProd'])) {
    $flag = false;
    $db = new Database();
    $flag = $db->eliminarProducto($_GET['delProd']);
    if ($flag)
        AlertMessage('Producto eliminado correctamente', "");
    else
        AlertMessage('No se realizaron modificaciones.', "");
    }
if (isset($_POST['modCant']) && isset($_POST['mprodId'])) {
    $db = new Database();
    $flag = false;
    if ($_POST['modCant'] != "")
        $flag = $db->modCantidadProd($_POST['mprodId'], $_POST['modCant']);
    //header('location: users.php');
}
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
    <h1>Mi carrito</h1>
    <h2><?php 
        saludoSexo($_SESSION['usrSex']);
        ?>
    </h2>
    <?php
    $db = new Database();
    echo "
    <table class='table table-striped'>
    <thead>
        <th>No.</th>
        <th>Nombre del producto</th>
        <th>Precio unitario</th>
        <th>Cantidad</th>
        <th>Sub total</th>
        <th>Descripcion del producto</th>
        <th>Administrar</th></thead>";
    if($db->getProducts($_SESSION['usrUsername']) == 0)
        echo "<h3>Oh!, parece que aún no has agregado algun producto, puedes comenzar visitando nuestro <a href='https://mercadolibre.com'>cátalogo</a>.</h3>";
    else{
        echo"</table>";
    }
     ?>
</div>
</body>
<footer>
    <?php include '../assets/dependencies/foot.php' ?>
</footer>

</html>