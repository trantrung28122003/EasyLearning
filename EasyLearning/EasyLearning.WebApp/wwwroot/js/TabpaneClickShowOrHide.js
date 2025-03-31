
    // Bắt sự kiện click trên các tab
    document.querySelectorAll('.collapseContainer .nav-link').forEach(tab => {
        tab.addEventListener('click', function (e) {
            //e.preventDefault(); // Ngăn chặn hành động mặc định của thẻ a
            const targetId = this.getAttribute('href').replace('#', ''); // Lấy id của tab được chọn
            showTab(targetId); // Hiển thị tab tương ứng
        });
    });

    // Hàm hiển thị tab tương ứng
    function showTab(tabId) {
        // Ẩn tất cả các tab
        document.querySelectorAll('.tab-pane').forEach(tab => {
            tab.classList.remove('show', 'active');
        });
    // Hiển thị tab được chọn
    document.getElementById(tabId).classList.add('show', 'active');

        // Đặt thuộc tính aria-selected
        document.querySelectorAll('.nav-link').forEach(tab => {
        tab.setAttribute('aria-selected', 'false');
        });
    document.querySelector('[href="#' + tabId + '"]').setAttribute('aria-selected', 'true');
    }
