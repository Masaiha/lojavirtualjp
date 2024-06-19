function SetModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });
            $("a[data-modal]").on("click",
                function (e) {
                    $('#ModalFMContent').load(this.href,
                        function () {
                            //$('.loader').eq(0).hide();
                            $('#ModalFM').modal({
                                keyboard: true
                            },
                                'show')
                        });

                    return false;
                });
        });
    });
}

function SetTitleModal(title) {
    $('#ModalFMTitleText').text(title);
}