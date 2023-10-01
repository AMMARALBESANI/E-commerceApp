$(document).ready(function () {
    $('.btn-number').click(function (e) {
        e.preventDefault();

        var fieldName = $(this).data('field');
        var type = $(this).data('type');
        var input = $(this).closest('.input-group').find('.input-number');
        var currentVal = parseInt(input.val());

        if (!isNaN(currentVal)) {
            if (type === 'minus') {
                if (currentVal > input.attr('min')) {
                    input.val(currentVal - 1).change();
                }
            } else if (type === 'plus') {
                if (currentVal < input.attr('max')) {
                    input.val(currentVal + 1).change();
                }
            }
        } else {
            input.val(0);
        }
    });
});