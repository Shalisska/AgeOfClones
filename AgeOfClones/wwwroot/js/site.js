$(document).ready(function () {
    var numberInputs = 'input[data-val-number]:not([type="hidden"])';

    $('body').on('change', numberInputs, function () {
        var val = $(this).val();
        var newVal = val.replace('.', ',');
        $(this).val(newVal);
    });
});

$(document).ready(function () {
    $('body').on('click', '#update-transaction', function () {
        var form = $('#transaction-form');
        var container = form.parents('.ui-dialog-content');
        var input = {
            currencyId: form.find('#currencyId').val(),
            value: form.find('#value').val(),
            correspondingId: form.find('#correspondingId').val()
        };

        $.ajax({
            url: $(this).data('update'),
            method: 'Post',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(input),
            success: function (data) {
                console.log(container);
                container.html(data);
            }
        });
    });
});