<meta charset="UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<?php
if (isset($_SESSION['rol'])) {
    if (basename($_SERVER["PHP_SELF"]) == "404.php" || basename($_SERVER["PHP_SELF"]) == "403.php") {
        echo '
        <link rel="stylesheet" href="../../assets/css/bootstrap.css">
        <link rel="stylesheet" href="../../assets/css/styles.css">
        <script src="../../assets/js/bootstrap.js"></script>
        <script src="../../assets/js/script.js"></script>
        ';
    } else if (basename($_SERVER["PHP_SELF"]) == "index.php") {
        echo '
        <link rel="stylesheet" href="assets/css/bootstrap.css">
        <link rel="stylesheet" href="assets/css/styles.css">
        <script src="assets/js/bootstrap.js"></script>
        <script src="assets/js/script.js"></script>
        ';
    } else {
        if (basename($_SERVER['PHP_SELF']) == 'users.php')
            echo '
                <link rel="stylesheet" href="../../assets/css/bootstrap.css">
                <link rel="stylesheet" href="../../assets/css/styles.css">
                <script src="../../assets/js/bootstrap.js"></script>
                <script src="../../assets/js/script.js"></script>';
        else
            echo '
                <link rel="stylesheet" href="../assets/css/bootstrap.css">
                <link rel="stylesheet" href="../assets/css/styles.css">
                <script src="../assets/js/bootstrap.js"></script>
                <script src="../assets/js/script.js"></script>';
    }
} else {
    echo '
        <link rel="stylesheet" href="assets/css/bootstrap.css">
        <link rel="stylesheet" href="assets/css/styles.css">
        <script src="assets/js/bootstrap.js"></script>
        <script src="assets/js/script.js"></script>';
}
?>