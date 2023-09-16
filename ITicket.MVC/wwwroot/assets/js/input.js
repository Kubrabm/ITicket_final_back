// Input alanı ve değeri al
var miktarInput = document.getElementById('miktar');
var miktar = 0; // Başlangıçta sıfır

// Artırma işlevi
function increase() {
    miktar++;
    miktarInput.value = miktar;
}

// Azaltma işlevi
function decrease() {
    if (miktar > 0) {
        miktar--;
        miktarInput.value = miktar;
    }
}

