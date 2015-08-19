function vahetus(){
$.ajax(
{ type: 'GET', url:"currency"+$('#valuuta').find(":selected").text(), success: function (response) {
        $('#confirm').html(response);

}})
}