<?php
class DataBase
{
    private $hotsname = 'the.axolotlteam.com';
    private $connectioninfo = array(
        "database" => 'AxoloMercadito',
        "uid" => 'apiWebUser',
        "pwd" => '^u4U5#keVl#7DKcj'
    );
    public function __construct()
    {
    }

    public function connect()
    {
        $conn = sqlsrv_connect($this->hotsname, $this->connectioninfo);

        if ($conn) {
            //echo "Logré conectarme.\n";
            return $conn;
        } else {
            echo "Connection could not be established.\n";
            die(print_r(sqlsrv_errors(), true));
        }
    }
    // 
    public function getHash($usrUsername)
    {
        $conn = $this->connect();

        $sql = 'SELECT * FROM Users WHERE usrUsername = ?;';
        $params = array($usrUsername);

        $stmt = sqlsrv_query($conn, $sql, $params);
        $row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC);

        if ($row) {
            $hash = $row['usrPassword'];
            return $hash;
        }
    }
    public function getUsers()
    {
        $sql = "SELECT * FROM Users";
        $conn = $this->connect();
        $stmt = sqlsrv_query($conn, $sql);
        if ($stmt === false) {
            die(print_r(sqlsrv_errors(), true));
            printf("Algo fallo");
        }
        while ($row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)) {
            echo "<form method='POST' action='#'><tr>";
            echo "<td>" . $row['usrId'];
            echo "<input type='hidden' name='modId' value='" . $row['usrId'] . "'>";
            if ($_SESSION['rol'] == 3){
                echo "<td>";
                switch($row['rolId']){
                    case 3:
                        echo "<a data-toggle='tooltip' data-placement='top' title='Administrador'>";
                        break;
                    case 2:
                        echo "<a data-toggle='tooltip' data-placement='top' title='Moderador'>";
                        break;
                    default:
                    echo "<a data-toggle='tooltip' data-placement='top' title='Usuario'>";
                        break;
                    }
                echo "<input class='form-control' type='number' min='1' max='3' name='modRol' id='rolId' placeholder='" . $row['rolId'] . "'></a>";
            } else 
                switch($row['rolId']){
                    case 3:
                        echo "<td><a data-toggle='tooltip' data-placement='top' title='Administrador'>Administrador</a>";
                        break;
                    case 2:
                        echo "<td><a data-toggle='tooltip' data-placement='top' title='Moderador'>Moderador</a>";
                        break;
                    default:
                    echo "<td><a data-toggle='tooltip' data-placement='top' title='Usuario'>Usuario</a>";
                        break;
                }
                if($row['rolId']==1 || $_SESSION['rol']==3){
                    echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrUsername'] . "'><input class='form-control' type='text' name='modUsername' id='usrFname' placeholder='" . $row['usrUsername'] . "'></a>";
                    echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrFname'] . "'><input class='form-control' type='text' name='modFname' id='usrFname' placeholder='" . $row['usrFname'] . "'></a>";
                    echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrLname'] . "'><input class='form-control' type='text' name='modLname' id='usrFname' placeholder='" . $row['usrLname'] . "'></a>";
                    echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrEmail'] . "'><input class='form-control' type='email' name='modEmail' id='usrFname' placeholder='" . $row['usrEmail'] . "'></a>";
                    echo "</td><td><input class='form-control' type='password' name='modPassword' id='usrPassword' placeholder='Cambiar contraseña'>";
                    echo "</td>
                            <td>
                                <div class='btn-group' role='group'>
                                        <button type='submit' class='btn btn-primary' id='cmdModify'>Modificar</button>
                                    <a href='users.php?delUser=" . $row['usrId'] . "'>
                                        <button type='button' class='btn btn-danger' id='cmdDelete'>Eliminar</button>
                                    </a>
                                </div>
                            </td>
                        </tr>
                    </form>";
                }
                else{
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrUsername'] . "'><input class='form-control' type='text' name='modUsername' id='usrFname' placeholder='" . $row['usrUsername'] . "' disabled></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrFname'] . "'><input class='form-control' type='text' name='modFname' id='usrFname' placeholder='" . $row['usrFname'] . "' disabled></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrLname'] . "'><input class='form-control' type='text' name='modLname' id='usrFname' placeholder='" . $row['usrLname'] . "' disabled></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['usrEmail'] . "'><input class='form-control' type='email' name='modEmail' id='usrFname' placeholder='" . $row['usrEmail'] . "' disabled></a>";
            echo "</td><td><input class='form-control' type='password' name='modPassword' id='usrPassword' placeholder='Cambiar contraseña' disabled>";
            echo "</td>
                    <td>
                        <div class='btn-group' role='group'>
                                <button type='submit' class='btn btn-primary' id='cmdModify' disabled>Modificar</button>
                                <button type='button' class='btn btn-danger' id='cmdDelete' disabled>Eliminar</button>
                        </div>
                    </td>
                </tr>
            </form>";
                }
        }
    }
    function EliminarUsuario($usrId)
    {
        $sql = "EXEC deleteUsuario ? ;";
        $params = array($usrId);

        $conn = $this->connect();
        $stmt = sqlsrv_query($conn, $sql, $params);
        if ($stmt === false) {
            die(print_r(sqlsrv_errors(), true));
        } else return true;
    }
    function ModificarUsuario($id, $attrib, $parm)
    {
        $sql = "UPDATE Users SET " . $attrib . "=? WHERE usrId=?";
        $params = array($parm, $id);

        $conn = $this->connect();
        $stmt = sqlsrv_query($conn, $sql, $params);
        if ($stmt === false) {
            die(print_r(sqlsrv_errors(), true));
            AlertMessage("Hubo un error al modificar el usuario.", "");
        } else return true;
    }
    public function getProducts($usrUsername)
    {
        $sql = "EXEC miLista ?";
        $params = array($usrUsername);
        $conn = $this->connect();
        $stmt = sqlsrv_query($conn, $sql, $params);
        if ($stmt === false) {
            die(print_r(sqlsrv_errors(), true));
            printf("Algo fallo");
        }
        $cont = 0;
        while ($row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)) {
            echo "<form method='POST' action='#'><tr>";
            echo "<input type='hidden' name='mprodId' value='" . $row['mprodId'] . "'>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='Producto ".++$cont."'>".$cont."</a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='".$row['prodName']."'><input class='form-control' type='text'  value='" . $row['prodName'] . "' disabled></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='Precio del producto'><input class='form-control' type='text'  value='$" . $row['prodPrice'] . "' disabled></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='Cantidad del producto'><input class='form-control' type='number' name='modCant' id='modCant' min=1 value='" . $row['mprodCantidad'] . "' ></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='Total del producto'><input class='form-control' type='text' value='$" . $row['prodPrice']*$row['mprodCantidad'] . "' disabled></a>";
            echo "</td><td><a data-toggle='tooltip' data-placement='top' title='" . $row['prodDesc'] . "'><input class='form-control' type='text' value='" . $row['prodDesc'] . "' disabled></a>";
            echo "</td>
                    <td>
                        <div class='btn-group' role='group'>
                                <button type='submit' class='btn btn-primary' id='cmdModify'>Modificar</button>
                            <a href='welcome.php?delProd=" . $row['mprodId'] . "'>
                                <button type='button' class='btn btn-danger' id='cmdDelete'>Eliminar</button>
                            </a>
                        </div>
                    </td>
                </tr>
            </form>";
        }
        return $cont;
    }
    function eliminarProducto($prodId)
    {
        $sql = "DELETE FROM MisProductos WHERE mprodId= ? ;";
        $params = array($prodId);

        $conn = $this->connect();
        $stmt = sqlsrv_query($conn, $sql, $params);
        if ($stmt === false) {
            die(print_r(sqlsrv_errors(), true));
        } else return true;
    }
    function modCantidadProd($id, $cant)
    {
        $sql = "UPDATE MisProductos SET mprodCantidad=? WHERE mprodId=?;";
        $params = array($cant, $id);

        $conn = $this->connect();
        $stmt = sqlsrv_query($conn, $sql, $params);
        if ($stmt === false) {
            die(print_r(sqlsrv_errors(), true));
            AlertMessage("Hubo un error al modificar la cantidad de producto.", "");
        } else return true;
    }
}
function AlertMessage($message, $ruta)
{
    echo '<script language="javascript">';
    echo 'alert("' . $message . '")';  //not showing an alert box.
    if ($ruta != '') {
        echo 'window.location.href = "' . "$ruta" . '";';
        echo "</script>";
    } else
        echo "</script>";
}

