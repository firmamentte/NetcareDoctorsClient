const generalUserSearchDoctorsProfile = () => {

    showPopupFormProgressBar()

    fetch("/GeneralUserDoctorsProfile/SearchDoctorsProfile").
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

const generalUserSubmitSearchDoctorsProfile = () => {

    toggleButtonProgressBar(document.querySelector("#navSearchDoctorsProfile"), document.querySelector("#progressBarSearchDoctorsProfile"))

    fetch("/GeneralUserDoctorsProfile/SearchDoctorsProfile", postOptions(serialize(document.querySelector("#formSearchDoctorsProfileForm")))).
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