function hideAllFilteredDivs() {
    $('#detailedResultsSynopsis').hide();
    $('#detailedResultsGenres').hide();
    $('#detailedResultsAwards').hide();
    $('#detailedResultsCast').hide();
    $('#detailedResultsOtherInfo').hide();
}

function showAllFilteredDivs() {
    $('#detailedResultsSynopsis').show();
    $('#detailedResultsGenres').show();
    $('#detailedResultsAwards').show();
    $('#detailedResultsCast').show();
    $('#detailedResultsOtherInfo').show();
}

function sanitizeInput(searchText) {
    var returnText = searchText.Trim();
    //could do other cleanup later on
    return returnText;
}

function addNewCard()
{
    var getUrl = window.location;
    var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
    location.href = baseUrl + 'magiccards/create';
}


$("#universalTextBox").keyup(function (event) {
    if (event.keyCode === 13) {
        $("#submitSearchQueryButton").click();
    }
});

function submitTextSearch() {
    $('#loadingDiv').show();
    $('#SearchByDropDownDiv').hide();
    $('#detailedMediaResultsDivResult').hide();
    $('#searchByTitleResultDiv').hide();
    $.ajax({
        type: "POST",
        url: "/MagicCards/GetCardsInitialSearch/",
        data: { inputSearchText: $('#universalTextBox').val() },
    }).success(function (result) {
        $('#loadingDiv').hide();
        $('#searchByCardNameResultDiv').html(result);
        $('#searchByCardNameResultDiv').show();
        }).error(function (result) {
            alert('An unexpected error has occurred. Please try again.');
            location.reload();
    });
}

function showAllCards() {
    $('#loadingDiv').show();
    $('#SearchByDropDownDiv').hide();
    $('#detailedMediaResultsDivResult').hide();
    $('#searchByTitleResultDiv').hide();
    var all = '';
    $.ajax({
        type: "POST",
        url: "/MagicCards/GetCardsInitialSearch/",
        data: { inputSearchText: all },
    }).success(function (result) {
        $('#loadingDiv').hide();
        $('#searchByCardNameResultDiv').html(result);
        $('#searchByCardNameResultDiv').show();
    }).error(function (result) {
        alert('An unexpected error has occurred. Please try again.');
        location.reload();
    });
}

function loadDetailsView(Id) {
    $('#loadingDiv').show();
    $('#SearchByDropDownDiv').hide();
    $('#detailedMediaResultsDivResult').hide();
    $('#searchByCardNameResultDiv').hide();
    $.ajax({
        type: "POST",
        url: "/MagicCards/Details/",
        data: { id : Id },
    }).success(function (result) {
        $('#loadingDiv').hide();
        $('#WelcomeDiv').hide();
        $('#SearchDiv').hide();
        $('#detailedMediaResultsDivResult').html(result);
        $('#detailedMediaResultsDivResult').show();
        $('#SearchByDropDownDiv').show();
        $('#universalTextBox').val($('#movieSelected').text());
    }).error(function (result) {
        alert('An unexpected error has occurred. Please try again.');
        location.reload();
    });
}