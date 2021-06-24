<?php
$Links = array(
    "home" => "",
    "signin" => "",
    "signup" => "",
    "signout" => array(
        "method" => "signOut",
        "action" => "../../login.php"
    ),
    "panel" => array(
        "principal" => "",
        "usuarios" => "",
        "myPanel" => ""
    )
);
$Sources = array(
    "logo" => "assets/img/icon/Carrito.png"
);
if (basename($_SERVER["PHP_SELF"]) == "404.php" || basename($_SERVER["PHP_SELF"]) == "403.php") {
    $Sources['logo'] = '../../assets/img/icon/Carrito.png';
    $Links['home'] = '../../index.php';
    $Links['signup'] = '../../registration.php';
    $Links['signin'] = "../../login.php";
    $Links['panel']['principal'] = "../../login.php";
    $Links['panel']['usuarios'] = "../../manage/users.php";
} else if (isset($_SESSION['rol'])) {
    if (basename($_SERVER["PHP_SELF"]) == "index.php") {
        $Sources['logo'] = 'assets/img/icon/Carrito.png';
        $Links['panel']['principal'] = "login.php";
        $Links['panel']['usuarios'] = "sesion/manage/users.php";
        $Links['signout']['action'] = "login.php";
    } else {
        if (basename($_SERVER['PHP_SELF']) == 'users.php') {
            $Sources['logo'] = '../../assets/img/icon/Carrito.png';
            $Links['home'] = '../../index.php';
            $Links['panel']['principal'] = "../../login.php";
            $Links['signout']['action'] = "../../login.php";
        } else {
            $Sources['logo'] = '../assets/img/icon/Carrito.png';
            $Links['home'] = '../index.php';
            switch ($_SESSION['rol']) {
                case 3:
                case 2:
                    $Links['panel']['usuarios'] = "manage/users.php";
                    break;
                default:
                    break;
            }
            $Links['panel']['myPanel'] = "../sesion/myPanel.php";
            $Links['signout']['action'] = "../login.php";
        }
    }
} else {
    $Sources['logo'] = 'assets/img/icon/Carrito.png';
    $Links['home'] = 'index.php';
    $Links['signup'] = 'registration.php';
    $Links['signin'] = "login.php";
}
?>

<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
        <a class="navbar-brand">
            <img src='<?php echo $Sources['logo']; ?>' style="width: 32px; height:32px;" alt="Bee">
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item">
                    <a class="nav-link active" aria-current="page" href='<?php echo $Links['home']; ?>'>Inicio</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Sobre nosotros</a>
                </li>
                <li class="nav-item dropdown">
                </li>
                <?php
                if (isset($_SESSION['rol'])) {
                    echo <<<EOT
                            <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                Mi mercadito
                            </a>
                                <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="{$Links['panel']['principal']}">Ir a mi carrito</a></li>
                            EOT;
                    switch ($_SESSION['rol']) {
                        case 3:
                        case 2:
                            echo "<li><a class='dropdown-item' href='" . $Links['panel']['usuarios'] . "'>Administrar usuarios</a></li>";
                            break;
                        default:
                            break;
                    }
                    echo "
                        <li>
                            <hr class='dropdown-divider'>
                        </li>
                        <li><a class='dropdown-item' href='" /*. $Links["panel"]["myPanel"]*/ . "#'>Mi configuración (nd)</a></li>
                    </ul>
                </li>";
                }
                ?>
            </ul>
            <?php
            if (!isset($_SESSION['rol']))
                if (basename($_SERVER['PHP_SELF']) == 'login.php') {
                    echo <<<EOT
                    <form class="d-flex" action="{$Links['signup']}">
                        <button class="btn btn-outline-success" type="submit">Registrarme</button>
                    </form> 
                EOT;
                } else {
                    echo <<<EOT
                    <form class="d-flex" action="{$Links['signin']}">
                        <button class="btn btn-outline-success" type="submit">Iniciar sesión</button>
                    </form> 
                EOT;
                    if (basename($_SERVER['PHP_SELF']) != 'registration.php') {
                        echo <<<EOT
                        <form class="d-flex" action="{$Links['signup']}">
                            <button class="btn btn-outline-success" type="submit">Registrarme</button>
                        </form>
                    EOT;
                    }
                }
            else
                echo <<<EOT
                <form class="d-flex" action="{$Links['signout']['action']}">
                    <button class="btn btn-outline-success" type="submit" name="{$Links['signout']['method']}">Cerrar sesión</button>
                </form>
            EOT;
            ?>
        </div>
    </div>
</nav>