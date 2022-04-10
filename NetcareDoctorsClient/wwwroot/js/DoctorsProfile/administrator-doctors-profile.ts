const administratorSearchDoctorsProfile = () => {

    showPopupFormProgressBar()

    fetch("/AdministratorDoctorsProfile/SearchDoctorsProfile").
        then(handleError).
        then(htmlDataType).
        then((data) => {

            showPopupFormHtml(data)

            fillSearchDoctorsProfileValues()
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const administratorSubmitSearchDoctorsProfile = () => {

    toggleButtonProgressBar(document.querySelector("#navSearchDoctorsProfile"), document.querySelector("#progressBarSearchDoctorsProfile"))

    fetch("/AdministratorDoctorsProfile/SearchDoctorsProfile", postOptions(serialize(document.querySelector("#formSearchDoctorsProfileForm")))).
        then(handleError).
        then(htmlDataType).
        then((data) => {

            storeSearchDoctorsProfileValues()

            document.querySelector("#divDoctorsProfileGrid").innerHTML = data

            hidePopupForm()
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const createDoctorProfile = () => {

    showPopupFormProgressBar()

    fetch("/AdministratorDoctorsProfile/CreateDoctorProfile").
        then(handleError).
        then(htmlDataType).
        then((data) => {

            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const submitCreateDoctorProfile = () => {

    const _messageCreateDoctorProfile = clearErrorMessageDiv(document.querySelector("#messageCreateDoctorProfile"))

    validateCreateEditDoctorProfile(_messageCreateDoctorProfile)

    if (!isErrorMessageDivEmpty(_messageCreateDoctorProfile)) {
        return
    }

    toggleButtonProgressBar(document.querySelector("#navCreateDoctorProfile"), document.querySelector("#progressBarCreateDoctorProfile"))

    fetch("/AdministratorDoctorsProfile/CreateDoctorProfile", postOptions(serialize(document.querySelector("#formCreateDoctorProfileForm")))).
        then(handleError).
        then(htmlDataType).
        then((data) => {

            const _gvRowMessage = document.querySelector("#divDoctorsProfileGrid .grid-view .gv-row-message")
            if (!!_gvRowMessage) {

                _gvRowMessage.remove()

                document.querySelector("#divDoctorsProfileGrid .grid-view").innerHTML = data
            }
            else {
                document.querySelector("#divDoctorsProfileGrid .grid-view").insertAdjacentHTML("afterbegin", data)
            }

            hidePopupForm()
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const editDoctorProfile = (doctorProfileId) => {

    showPopupFormProgressBar()

    fetch(`/AdministratorDoctorsProfile/EditDoctorProfile?doctorProfileId=${doctorProfileId}`).
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const submitEditDoctorProfile = () => {

    const _messageEditDoctorProfile = clearErrorMessageDiv(document.querySelector("#messageEditDoctorProfile"))

    validateCreateEditDoctorProfile(_messageEditDoctorProfile)

    if (!isErrorMessageDivEmpty(_messageEditDoctorProfile)) {
        return
    }

    toggleButtonProgressBar(document.querySelector("#navEditDoctorProfile"), document.querySelector("#progressBarEditDoctorProfile"))

    fetch("/AdministratorDoctorsProfile/EditDoctorProfile", postOptions(serialize(document.querySelector("#formEditDoctorProfileForm")))).
        then(handleError).
        then(htmlDataType).
        then((data) => {

            const _data = document.createElement("div")
            _data.innerHTML = data

            document.querySelector(`#divDoctorsProfileGrid .grid-view #${CSS.escape((<HTMLInputElement>_data.querySelector(".hfDoctorProfileId")).value)}`).innerHTML = _data.innerHTML

            hidePopupForm()
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const yesNo = (actionController, actionMethod, actionValue) => {

    onBeginYesNo()

    fetch(`/${actionController}/${actionMethod}`, postOptions(`actionValue=${actionValue}`)).
        then(handleError).
        then(() => {

            document.querySelector(`#divDoctorsProfileGrid .grid-view #${CSS.escape(actionValue)}`).remove()

            if (document.querySelectorAll("#divDoctorsProfileGrid .grid-view .gv-row").length <= 0) {

                document.querySelector("#divDoctorsProfileGrid .grid-view").innerHTML =
                    gridViewMessage("Please use the buttons above to search or add Doctors Profile...")
            }

            hidePopupForm()
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

function validateCreateEditDoctorProfile(messageDiv: HTMLDivElement) {

    if (!(!!(<HTMLInputElement>document.querySelector("#TitleName")).value.trim())) {
        appendErrorMessage(messageDiv, "Title required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#FirstName")).value.trim())) {
        appendErrorMessage(messageDiv, "First Name required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#LastName")).value.trim())) {
        appendErrorMessage(messageDiv, "Last Name required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#HpcsaNo")).value.trim())) {
        appendErrorMessage(messageDiv, "HPCSA No. required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#IdNo")).value.trim())) {
        appendErrorMessage(messageDiv, "ID No. required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#DisciplineName")).value.trim())) {
        appendErrorMessage(messageDiv, "Discipline required")
    }

    if (!(!!(<HTMLInputElement>document.querySelector("#ProvinceName")).value.trim())) {
        appendErrorMessage(messageDiv, "Province required")
    }
}
