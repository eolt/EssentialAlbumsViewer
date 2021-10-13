
// We display albums of an artist in either critial or commerical order.

// When the user clicks on an input, the JavaScript function calls the controller to
// return the list of albums back to the view in a different sorted order. 

//  We do these calls by changing the url address. 

function sortByCritics(id) {
    window.location.href = "/Artist/Details/"+String(id);
}

function sortByCommercial(id) {
    window.location.href = "/Artist/Details/" + String(id) +"?sortby=commercial";
}

function sortByAwards(id) {
    window.location.href = "/Artist/Details/" + String(id) +"?sortby=awards";
}

function sortByOnline(id) {
    window.location.href = "/Artist/Details/" + String(id) + "?sortby=online";
}



