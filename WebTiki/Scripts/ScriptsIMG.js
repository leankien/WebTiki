function ShowImagePreview(imageUpploader, previewImage) {
    if (imageUpploader.files && imageUpploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUpploader.files[0]);
    }
}