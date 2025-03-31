<script>
    function addToCart(courseId) {
        $.ajax({
            url: '/ShoppingCart/AddToCart',
            type: 'POST',
            data: { courseId: courseId },
            success: function (data) {
                // Xử lý khi thêm vào giỏ hàng thành công (nếu cần)
                alert('Đã thêm vào giỏ hàng thành công!');
                updateCartItemCount(data);
            },
            error: function (xhr, status, error) {
                // Xử lý khi có lỗi xảy ra (nếu cần)
                console.error(error);
                alert('Có lỗi xảy ra khi thêm vào giỏ hàng. Vui lòng thử lại sau.');
            }
        });
    }

    function updateCartItemCount(itemCount) {
        var cartItemCountSpan = document.getElementById('cartItemCount');
    if (cartItemCountSpan) {
        cartItemCountSpan.textContent = itemCount;
        }
    }
</script>