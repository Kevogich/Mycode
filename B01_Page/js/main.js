var ourList = document.getElementById("our-list");
var ourButton = document.getElementById("our-button");
var ourHeadline = document.getElementById("our-headLine");
var listItems = document.getElementById("our-list").getElementsByTagName("li");

for(i=0;i<listItems.length; i++){
   // listItems[i].innerHTML="HELLO WORLD";
    listItems[i].addEventListener("click",activateItem);

}

function activateItem(){
    //alert("click detected");
    ourHeadline.innerHTML = this.innerHTML;
}

ourButton.addEventListener("click",createNewitem);
function createNewitem(){
ourList.innerHTML += "<li>something new</li>";
}