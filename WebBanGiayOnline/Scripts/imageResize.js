function resizeImage() {
    const fileInput = document.getElementById('fileInput');
    const files = fileInput.files;

    if (files.length > 0) {
        const file = files[0];
        const reader = new FileReader();

        reader.onload = function (e) {
            const img = new Image();
            img.src = e.target.result;

            img.onload = function () {
                const canvas = document.createElement('canvas');
                const ctx = canvas.getContext('2d');

                const width = 200;
                const height = 145.79;

                canvas.width = width;
                canvas.height = height;

                ctx.drawImage(img, 0, 0, width, height);

                canvas.toBlob(function (blob) {
                    const resizedFile = new File([blob], file.name, {
                        type: 'image/jpeg',
                        lastModified: Date.now()
                    });

                    uploadResizedImage(resizedFile);
                }, 'image/jpeg');
            }
        }

        reader.readAsDataURL(file);
    }
}

function uploadResizedImage(file) {
    const formData = new FormData();
    formData.append('upload', file);

    fetch('/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Images', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data && data.uploaded) {
                console.log('Image uploaded successfully:', data.url);
                // Xử lý sau khi tải lên thành công (ví dụ: hiển thị ảnh)
            } else {
                console.error('Upload failed:', data.error.message);
            }
        })
        .catch(error => {
            console.error('Error uploading image:', error);
        });
}
