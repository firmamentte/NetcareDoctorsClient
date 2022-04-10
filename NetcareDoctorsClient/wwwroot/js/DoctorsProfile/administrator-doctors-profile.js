var administratorSearchDoctorsProfile = function () {
    showPopupFormProgressBar();
    fetch("/AdministratorDoctorsProfile/SearchDoctorsProfile").
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
var administratorSubmitSearchDoctorsProfile = function () {
    toggleButtonProgressBar(document.querySelector("#navSearchDoctorsProfile"), document.querySelector("#progressBarSearchDoctorsProfile"));
    fetch("/AdministratorDoctorsProfile/SearchDoctorsProfile", postOptions(serialize(document.querySelector("#formSearchDoctorsProfileForm")))).
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
var createDoctorProfile = function () {
    showPopupFormProgressBar();
    fetch("/AdministratorDoctorsProfile/CreateDoctorProfile").
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var submitCreateDoctorProfile = function () {
    var _messageCreateDoctorProfile = clearErrorMessageDiv(document.querySelector("#messageCreateDoctorProfile"));
    validateCreateEditDoctorProfile(_messageCreateDoctorProfile);
    if (!isErrorMessageDivEmpty(_messageCreateDoctorProfile)) {
        return;
    }
    toggleButtonProgressBar(document.querySelector("#navCreateDoctorProfile"), document.querySelector("#progressBarCreateDoctorProfile"));
    fetch("/AdministratorDoctorsProfile/CreateDoctorProfile", postOptions(serialize(document.querySelector("#formCreateDoctorProfileForm")))).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        var _gvRowMessage = document.querySelector("#divDoctorsProfileGrid .grid-view .gv-row-message");
        if (!!_gvRowMessage) {
            _gvRowMessage.remove();
            document.querySelector("#divDoctorsProfileGrid .grid-view").innerHTML = data;
        }
        else {
            document.querySelector("#divDoctorsProfileGrid .grid-view").insertAdjacentHTML("afterbegin", data);
        }
        hidePopupForm();
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var editDoctorProfile = function (doctorProfileId) {
    showPopupFormProgressBar();
    fetch("/AdministratorDoctorsProfile/EditDoctorProfile?doctorProfileId=".concat(doctorProfileId)).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        showPopupFormHtml(data);
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var submitEditDoctorProfile = function () {
    var _messageEditDoctorProfile = clearErrorMessageDiv(document.querySelector("#messageEditDoctorProfile"));
    validateCreateEditDoctorProfile(_messageEditDoctorProfile);
    if (!isErrorMessageDivEmpty(_messageEditDoctorProfile)) {
        return;
    }
    toggleButtonProgressBar(document.querySelector("#navEditDoctorProfile"), document.querySelector("#progressBarEditDoctorProfile"));
    fetch("/AdministratorDoctorsProfile/EditDoctorProfile", postOptions(serialize(document.querySelector("#formEditDoctorProfileForm")))).
        then(handleError).
        then(htmlDataType).
        then(function (data) {
        var _data = document.createElement("div");
        _data.innerHTML = data;
        document.querySelector("#divDoctorsProfileGrid .grid-view #".concat(CSS.escape(_data.querySelector(".hfDoctorProfileId").value))).innerHTML = _data.innerHTML;
        hidePopupForm();
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
var yesNo = function (actionController, actionMethod, actionValue) {
    onBeginYesNo();
    fetch("/".concat(actionController, "/").concat(actionMethod), postOptions("actionValue=".concat(actionValue))).
        then(handleError).
        then(function () {
        document.querySelector("#divDoctorsProfileGrid .grid-view #".concat(CSS.escape(actionValue))).remove();
        if (document.querySelectorAll("#divDoctorsProfileGrid .grid-view .gv-row").length <= 0) {
            document.querySelector("#divDoctorsProfileGrid .grid-view").innerHTML =
                gridViewMessage("Please use the buttons above to search or add Doctors Profile...");
        }
        hidePopupForm();
    }).
        catch(function (error) {
        showErrorPopupForm(error);
    });
};
function validateCreateEditDoctorProfile(messageDiv) {
    if (!(!!document.querySelector("#TitleName").value.trim())) {
        appendErrorMessage(messageDiv, "Title required");
    }
    if (!(!!document.querySelector("#FirstName").value.trim())) {
        appendErrorMessage(messageDiv, "First Name required");
    }
    if (!(!!document.querySelector("#LastName").value.trim())) {
        appendErrorMessage(messageDiv, "Last Name required");
    }
    if (!(!!document.querySelector("#HpcsaNo").value.trim())) {
        appendErrorMessage(messageDiv, "HPCSA No. required");
    }
    if (!(!!document.querySelector("#IdNo").value.trim())) {
        appendErrorMessage(messageDiv, "ID No. required");
    }
    if (!(!!document.querySelector("#DisciplineName").value.trim())) {
        appendErrorMessage(messageDiv, "Discipline required");
    }
    if (!(!!document.querySelector("#ProvinceName").value.trim())) {
        appendErrorMessage(messageDiv, "Province required");
    }
}
//# sourceMappingURL=administrator-doctors-profile.js.map