var generalUserSearchDoctorsProfile = function () {
    showPopupFormProgressBar();
    fetch("/GeneralUserDoctorsProfile/SearchDoctorsProfile").
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
        fillSearchDoctorsProfileValues();
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var generalUserSubmitSearchDoctorsProfile = function () {
    toggleButtonProgressBar(document.querySelector("#navSearchDoctorsProfile"), document.querySelector("#progressBarSearchDoctorsProfile"));
    fetch("/GeneralUserDoctorsProfile/SearchDoctorsProfile", postOptions(serialize(document.querySelector("#formSearchDoctorsProfileForm")))).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        storeSearchDoctorsProfileValues();
        document.querySelector("#divDoctorsProfileGrid").innerHTML = data;
        hidePopupForm();
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
//# sourceMappingURL=general-user-doctors-profile.js.map