function vahetus(){
$.ajax(
{ type: 'Get', url:"Currency" +"?to="+$('#valuuta').find(":selected").text(), success: function (response) {
        $('#confirm').html(response);
        tableref();
        }})
}
function tableref(){
for (i=0;i<13;i++){
try{
	$("#i"+i).html((parseFloat(document.getElementById("a"+i).innerHTML)*parseFloat(document.getElementById("confirm").innerHTML.replace(/\s/g, ''))).toFixed(2)+$('#valuuta').find(":selected").text());
}
catch(err){

}
}
}