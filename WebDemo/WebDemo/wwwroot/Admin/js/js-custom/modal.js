var modal = {
    openPopup: function () {
        $('#btn-popup-open').off().on('click', function (e) {
            e.preventDefault();
            alert('open');
        });
    },
    closePopup: function () {
        $('#btn-popup-close').off().on('click', function (e) {
            e.preventDefault();
            alert('close');
        });
    },
    setMessage: function () {
        //$('#popupModal').on('show.bs.modal', function (event) {
        //    var button = $(event.relatedTarget); // Button that triggered the modal
        //    var recipient = button.data('whatever'); // Extract info from data-* attributes
        //    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        //    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        //    var modal = $(this)
        //    modal.find('.modal-title').text($("").data("content"));
        //    modal.find('.modal-body input').val(recipient);
        //});
    }
}

modal.openPopup();
modal.closePopup();
modal.setMessage();