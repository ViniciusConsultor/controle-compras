
function mascara(o, f) {
    v_obj = o
    v_fun = f
    setTimeout("execmascara()", 1)
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}

function leech(v) {
    v = v.replace(/o/gi, "0")
    v = v.replace(/i/gi, "1")
    v = v.replace(/z/gi, "2")
    v = v.replace(/e/gi, "3")
    v = v.replace(/a/gi, "4")
    v = v.replace(/s/gi, "5")
    v = v.replace(/t/gi, "7")
    return v
}

function soNumeros(v) {
    return v.replace(/\D/g, "")
}

function data(v) {

    v = v.replace(/\D/g, "")                 //Remove tudo o que não é dígito
    mask = "##/##/####"
    alert(masksaida = mask.substring(0, 1));
    saida = mask.substring(0, 1);
    texto = mask.substring(i)

    if (texto.substring(0, 1) != saida) {
        v.value += texto.substring(0, 1);
    }
    return v
}



function telefone(v) {
    v = v.replace(/\D/g, "")                 //Remove tudo o que não é dígito
    v = v.replace(/^(\d\d)(\d)/g, "($1) $2") //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d{4})(\d)/, "$1-$2")    //Coloca hífen entre o quarto e o quinto dígitos
    return v
}

function cpf(v) {
    v = v.replace(/\D/g, "")                    //Remove tudo o que não é dígito
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    v = v.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    //de novo (para o segundo bloco de números)
    v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos
    return v
}

function cep(v) {
    v = v.replace(/D/g, "")                //Remove tudo o que não é dígito
    v = v.replace(/^(\d{5})(\d)/, "$1-$2") //Esse é tão fácil que não merece explicações
    return v
}

function cnpj(v) {
    v = v.replace(/\D/g, "")                           //Remove tudo o que não é dígito
    v = v.replace(/^(\d{2})(\d)/, "$1.$2")             //Coloca ponto entre o segundo e o terceiro dígitos
    v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3") //Coloca ponto entre o quinto e o sexto dígitos
    v = v.replace(/\.(\d{3})(\d)/, ".$1/$2")           //Coloca uma barra entre o oitavo e o nono dígitos
    v = v.replace(/(\d{4})(\d)/, "$1-$2")              //Coloca um hífen depois do bloco de quatro dígitos
    return v
}

function sonumeros(fld, e) {
    var key = '';
    var strCheck = '0123456789';

    var whichCode = (window.Event) ? e.keyCode : e.which;

    if (whichCode == 13)
        return true;  // Enter
    key = String.fromCharCode(whichCode);  // Get key value from key code
    if (strCheck.indexOf(key) == -1) return false;  // Not a valid key

}


function currencyFormat(fld, milSep, decSep, e) {
    var sep = 0;
    var key = '';
    var i = j = 0;
    var len = len2 = 0;
    var strCheck = '0123456789';
    var aux = aux2 = '';

    var whichCode = (window.Event) ? e.keyCode : e.which;

    if (whichCode == 13)
        return true;  // Enter
    key = String.fromCharCode(whichCode);  // Get key value from key code
    if (strCheck.indexOf(key) == -1) return false;  // Not a valid key
    len = fld.value.length;
    for (i = 0; i < len; i++)
        if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
    aux = '';
    for (; i < len; i++)
        if (strCheck.indexOf(fld.value.charAt(i)) != -1) aux += fld.value.charAt(i);
    aux += key;
    len = aux.length;
    if (len == 0) fld.value = '';

    // Aqui tem que testar: se $Column->{decimals} for 3 coloca + '0' + '0' + senão, apenas + '0' +
    if (len == 1) fld.value = '0' + decSep + '0' + aux; // Alterei coloquei + '0' , decSep = , (vírgula)

    // Aqui tem que testar: se $Column->{decimals} for 3 coloca + '0' + senão, não coloca
    if (len == 2) fld.value = '0' + decSep + aux; // Alterei coloquei + '0'

    // Aqui tem que testar: se $Column->{decimals} for 3 coloca essa linha senão não coloca
    //if (len == 3) fld.value = '0' + decSep + aux + aux2; // Adicionei esta linha

    // Aqui tem que colocar a variável $decimal
    if (len > 2) { // Alterei de 2 para 3
        aux2 = '';

        // A cada três caracteres adiciona um milSep (ponto ".")
        for (j = 0, i = len - 3; i >= 0; i--) {
            if (j == 3) {
                aux2 += milSep;
                j = 0;
            }
            aux2 += aux.charAt(i);
            j++;
        }

        fld.value = '';
        len2 = aux2.length;

        // Aqui tem que testar: se $Column->{decimals} for 3 coloca i > 0 senão coloca i >= 0
        for (i = len2 - 1; i >= 0; i--) // Alterei de i >= 0 para i > 0
            fld.value += aux2.charAt(i);

        // Aqui tem que coloca a variável mo lugar do 3
        fld.value += decSep + aux.substr(len - 2, len); // O número dois é o valor chave (número de casas que vem depois da vírgula)
    }
    return false;
}