<?php
error_reporting(0);
$msg = "";

if (isset($_POST['upload'])) {
	$filename = "";
	$filename = $_FILES["uploadfile"]["name"];
	$tempname = $_FILES["uploadfile"]["tmp_name"];
	$folder = "./image/" . $filename;

	$db = mysqli_connect("localhost", "root", "", "arphoto");

	$sql = "INSERT INTO image (filename) VALUES ('$filename')";

	mysqli_query($db, $sql);

	if (move_uploaded_file($tempname, $folder)) {
		echo '<script type="text/javascript">
       window.onload = function () { alert("Success!"); } 
	</script>';
	} else {
		echo '<script type="text/javascript">
       window.onload = function () { alert("Failed to upload"); } 
	</script>';
	}
}
?>

<!DOCTYPE html>
<html>

<head>
	<title>Image Upload</title>
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="style.css" />
</head>

<body>
	<div id="content">
		<h1> Image Uploader </h1>
		<form method="POST" action="" enctype="multipart/form-data">
			<div class="form-group">
				<input class="form-control" type="file" name="uploadfile" value="" />
			</div>
			<div class="form-group">
				<button class="btn btn-primary" type="submit" name="upload">UPLOAD</button>
			</div>
		</form>
	</div>
	<div id="display-image">
		<?php
		$filename = '';
		$query = " select * from image ";
		$result = mysqli_query($db, $query);

		while ($data = mysqli_fetch_assoc($result)) {
		?>
			<img src="./image/<?php echo $data['filename']; ?>">

		<?php
		}
		?>
	</div>
</body>

</html>

