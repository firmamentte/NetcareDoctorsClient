var showErrorPopupForm = function (error) {
    fetch("/Shared/Ok?okMessage=".concat(error, "&messageSymbol=x")).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        console.log(error);
    });
};
var yesNoConfirmation = function (actionController, actionMethod, actionValue, yesNoMessage) {
    var _parameters = "?actionController=".concat(actionController, "\n         &actionMethod=").concat(actionMethod, "\n         &actionValue=").concat(actionValue, "\n         &yesNoMessage=").concat(yesNoMessage);
    showPopupFormProgressBar();
    fetch("/Shared/YesNo".concat(removeLineBreaks(_parameters))).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var viewState = {
    searchDoctorsProfileState: {
        IdNo: "",
        TitleName: "",
        FirstName: "",
        LastName: "",
        HpcsaNo: "",
        DisciplineName: "",
        ProvinceName: ""
    }
};
var storeSearchDoctorsProfileValues = function () {
    var _idNo = document.querySelector("#IdNo");
    viewState.searchDoctorsProfileState.IdNo = _idNo.value;
    var _titleName = document.querySelector("#TitleName");
    viewState.searchDoctorsProfileState.TitleName = _titleName.value;
    var _firstName = document.querySelector("#FirstName");
    viewState.searchDoctorsProfileState.FirstName = _firstName.value;
    var _lastName = document.querySelector("#LastName");
    viewState.searchDoctorsProfileState.LastName = _lastName.value;
    var _hpcsaNo = document.querySelector("#HpcsaNo");
    viewState.searchDoctorsProfileState.HpcsaNo = _hpcsaNo.value;
    var _disciplineName = document.querySelector("#DisciplineName");
    viewState.searchDoctorsProfileState.DisciplineName = _disciplineName.value;
    var _provinceName = document.querySelector("#ProvinceName");
    viewState.searchDoctorsProfileState.ProvinceName = _provinceName.value;
};
var fillSearchDoctorsProfileValues = function () {
    var _idNo = document.querySelector("#IdNo");
    _idNo.value = viewState.searchDoctorsProfileState.IdNo;
    var _titleName = document.querySelector("#TitleName");
    _titleName.value = viewState.searchDoctorsProfileState.TitleName;
    var _firstName = document.querySelector("#FirstName");
    _firstName.value = viewState.searchDoctorsProfileState.FirstName;
    var _lastName = document.querySelector("#LastName");
    _lastName.value = viewState.searchDoctorsProfileState.LastName;
    var _hpcsaNo = document.querySelector("#HpcsaNo");
    _hpcsaNo.value = viewState.searchDoctorsProfileState.HpcsaNo;
    var _disciplineName = document.querySelector("#DisciplineName");
    _disciplineName.value = viewState.searchDoctorsProfileState.DisciplineName;
    var _provinceName = document.querySelector("#ProvinceName");
    _provinceName.value = viewState.searchDoctorsProfileState.ProvinceName;
};
var userAccountMenu = function () {
    showPopupFormProgressBar();
    fetch("/Shared/UserAccount").
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var signOut = function () {
    window.location.assign("/ApplicationUser/UserSignOut");
};
var gridViewMessage = function (message) {
    return "<div class=\"gv-row-message\">\n            <span class=\"gv-message-value\">".concat(message, "</span>\n            </div>");
};
//# sourceMappingURL=site-shared.js.map