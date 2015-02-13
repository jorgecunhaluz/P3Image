$('.Date').mask("99/99/9999");
$('.Decimal').maskMoney({ showSymbol: false });
$(".Inteiro").keypress(verificaNumero);

function verificaNumero(e) {
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
}