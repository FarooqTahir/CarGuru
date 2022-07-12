function alertG(msg) {
    new PNotify({
        title: 'Success',
        text: msg,
        delay: 5000,
        type: 'success',
        addclass: 'pnotify-right'
    });
}
function alertR(msg) {
    new PNotify({
        title: 'Error',
        text: msg,
        delay: 5000,
        type: 'error',
        addclass: 'pnotify-right'
    });
}

$.clearInput = function (element) {
    $('#' + element + '').find('input[type=text], input[type=password], input[type=number], input[type=email], textarea').val('');
    $('#' + element + '').find("select").val($('#' + element + '').find("select option:first").val());
};