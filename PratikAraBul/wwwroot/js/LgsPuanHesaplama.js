

function hesapla() {
    //Türkçe
    var tdogru = document.lgshesapla.tdogru.value;
    var tyanlis = document.lgshesapla.tyanlis.value;
    var tnet = Number(tdogru - (tyanlis / 3).toFixed(2));
    document.lgssonuc.tnet.value = tnet;
   //Matematik
    var mdogru = document.lgshesapla.mdogru.value;
    var myanlis = document.lgshesapla.myanlis.value;
    var mnet = Number(mdogru - (myanlis / 3).toFixed(2));
    document.lgssonuc.mnet.value = mnet;
  //İnkılap
    var sdogru = document.lgshesapla.sdogru.value;
    var syanlis = document.lgshesapla.syanlis.value;
    var snet = Number(sdogru - (syanlis / 3).toFixed(2));
    document.lgssonuc.snet.value = snet;
   //Fen
    var fdogru = document.lgshesapla.fdogru.value;
    var fyanlis = document.lgshesapla.fyanlis.value;
    var fnet = Number(fdogru - (fyanlis / 3).toFixed(2));
    document.lgssonuc.fnet.value = fnet;
    //Din
    var dindogru = document.lgshesapla.dindogru.value;
    var dinyanlis = document.lgshesapla.dinyanlis.value;
    var dinnet = Number(dindogru - (dinyanlis / 3).toFixed(2));
    document.lgssonuc.dinnet.value = dinnet;
    //İngilizce
    var ingdogru = document.lgshesapla.ingdogru.value;
    var ingyanlis = document.lgshesapla.ingyanlis.value;
    var ingnet = Number(ingdogru - (ingyanlis / 3).toFixed(2));
    document.lgssonuc.ingnet.value = ingnet;
    //TOPLAM NET VE PUAN
    tpuan = Number(200+ (tnet * 3.45) + (snet * 1.48) + (mnet * 5.79) + (fnet * 3.56) + (dinnet * 1.59) + (ingnet + 1.34)).toFixed(2);
    document.lgssonuc.tpuan.value = tpuan;
    toplamnet = Number(tnet + mnet + fnet + snet + dinnet + ingnet).toFixed(2);
    document.lgssonuc.toplamnet.value = toplamnet;
    //Yüzdelik dilim hesabı

   

}

$(document).ready(function () {
    // Attach the keyup event listener to the input elements with unique IDs
    $("#trk_yirmisoru,#trk_yirmisoru_yanlis, #tc_onsoru,#tc_onsoru_yanlis, #mt_yirmisoru, #mt_yirmisoru_yanlis, #fb_yirmisoru, #fb_yirmisoru_yanlis,#dn_onsoru, #dn_onsoru_yanlis, #i_onsoru, #i_onsoru_yanlis").on("keyup", function (event) {
        uyari_mesajlari();
    });
});

var uyari_mesajlari = function () {
    var trk_yirmisoru = parseInt($("#trk_yirmisoru").val(), 10);
    var trk_yirmisoru_yanlis = parseInt($("#trk_yirmisoru_yanlis").val(), 10);
    var tc_onsoru = parseInt($("#tc_onsoru").val(), 10);
    var tc_onsoru_yanlis = parseInt($("#tc_onsoru_yanlis").val(), 10);
    var mt_yirmisoru = parseInt($("#mt_yirmisoru").val(), 10);
    var mt_yirmisoru_yanlis = parseInt($("#mt_yirmisoru_yanlis").val(), 10);
    var fb_yirmisoru = parseInt($("#fb_yirmisoru").val(), 10);
    var fb_yirmisoru_yanlis = parseInt($("#fb_yirmisoru_yanlis").val(), 10);
    var dn_onsoru = parseInt($("#dn_onsoru").val(), 10);
    var dn_onsoru_yanlis = parseInt($("#dn_onsoru_yanlis").val(), 10);
    var i_onsoru = parseInt($("#i_onsoru").val(), 10);
    var i_onsoru_yanlis = parseInt($("#i_onsoru_yanlis").val(), 10);
    if (trk_yirmisoru > 20 || trk_yirmisoru_yanlis > 20 || mt_yirmisoru > 20 || mt_yirmisoru_yanlis > 20 || fb_yirmisoru > 20 || fb_yirmisoru_yanlis>20) {
        $(".yirmisoru_uyari").html("Girilen sayı 20'den büyük olmamalıdır.");
    } else {
        $(".yirmisoru_uyari").html(""); // Clear the error message if the input is valid
    }
    if (tc_onsoru > 10 || tc_onsoru_yanlis > 10 || dn_onsoru > 10 || dn_onsoru_yanlis > 10 || i_onsoru > 10 || i_onsoru_yanlis>10) {
        $(".onsoru_uyari").html("Girilen sayı 10'dan büyük olmamalıdır.");
    } else {
        $(".onsoru_uyari").html(""); // Clear the error message if the input is valid
    }
    if ((trk_yirmisoru + trk_yirmisoru_yanlis) > 20 || (mt_yirmisoru + mt_yirmisoru_yanlis) > 20 || (fb_yirmisoru + fb_yirmisoru_yanlis) > 20) {
        $(".yirmisoru_uyari").html("Girilen sayıların toplamı 20'den küçük olmalıdır.");
    }
    else {
        $(".yirmisoru_uyari").html(""); // Clear the error message if the input is valid
    }
    if ( (tc_onsoru_yanlis + tc_onsoru) > 10 || (dn_onsoru + dn_onsoru_yanlis) > 10 || (i_onsoru + i_onsoru_yanlis) > 10) {
        $(".onsoru_uyari").html("Girilen sayıların toplamı 20'den küçük olmalıdır.");
    }
    else {
        $(".onsoru_uyari").html(""); // Clear the error message if the input is valid
    }
};


