const showErrorPopupForm = (error: string) => {

    fetch(`/Shared/Ok?okMessage=${error}&messageSymbol=x`).
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            console.log(error)
        })
}

const yesNoConfirmation = (actionController, actionMethod, actionValue, yesNoMessage) => {

    const _parameters =
        `?actionController=${actionController}
         &actionMethod=${actionMethod}
         &actionValue=${actionValue}
         &yesNoMessage=${yesNoMessage}`

    showPopupFormProgressBar()

    fetch(`/Shared/YesNo${removeLineBreaks(_parameters)}`).
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const viewState = {
    searchDoctorsProfileState: {
        IdNo: "",
        TitleName: "",
        FirstName: "",
        LastName: "",
        HpcsaNo: "",
        DisciplineName: "",
        ProvinceName: ""
    }
}

const storeSearchDoctorsProfileValues = () => {

    const _idNo: HTMLInputElement = document.querySelector("#IdNo")!
    viewState.searchDoctorsProfileState.IdNo = _idNo.value

    const _titleName: HTMLInputElement = document.querySelector("#TitleName")!
    viewState.searchDoctorsProfileState.TitleName = _titleName.value

    const _firstName: HTMLInputElement = document.querySelector("#FirstName")!
    viewState.searchDoctorsProfileState.FirstName = _firstName.value

    const _lastName: HTMLInputElement = document.querySelector("#LastName")!
    viewState.searchDoctorsProfileState.LastName = _lastName.value

    const _hpcsaNo: HTMLInputElement = document.querySelector("#HpcsaNo")!
    viewState.searchDoctorsProfileState.HpcsaNo = _hpcsaNo.value

    const _disciplineName: HTMLInputElement = document.querySelector("#DisciplineName")!
    viewState.searchDoctorsProfileState.DisciplineName = _disciplineName.value

    const _provinceName: HTMLInputElement = document.querySelector("#ProvinceName")!
    viewState.searchDoctorsProfileState.ProvinceName = _provinceName.value
}

const fillSearchDoctorsProfileValues = () => {

    const _idNo: HTMLInputElement = document.querySelector("#IdNo")!
    _idNo.value = viewState.searchDoctorsProfileState.IdNo

    const _titleName: HTMLInputElement = document.querySelector("#TitleName")!
    _titleName.value = viewState.searchDoctorsProfileState.TitleName

    const _firstName: HTMLInputElement = document.querySelector("#FirstName")!
    _firstName.value = viewState.searchDoctorsProfileState.FirstName

    const _lastName: HTMLInputElement = document.querySelector("#LastName")!
    _lastName.value = viewState.searchDoctorsProfileState.LastName

    const _hpcsaNo: HTMLInputElement = document.querySelector("#HpcsaNo")!
    _hpcsaNo.value = viewState.searchDoctorsProfileState.HpcsaNo

    const _disciplineName: HTMLInputElement = document.querySelector("#DisciplineName")!
    _disciplineName.value = viewState.searchDoctorsProfileState.DisciplineName

    const _provinceName: HTMLInputElement = document.querySelector("#ProvinceName")!
    _provinceName.value = viewState.searchDoctorsProfileState.ProvinceName
}

const userAccountMenu = () => {

    showPopupFormProgressBar()

    fetch("/Shared/UserAccount").
        then(handleError).
        then(htmlDataType).
        then((data) => {
            showPopupFormHtml(data)
        }).
        catch((error) => {
            showErrorPopupForm(error)
        })
}

const signOut = () => {
    window.location.assign("/ApplicationUser/UserSignOut")
}

const gridViewMessage = (message) => {
    return `<div class="gv-row-message">
            <span class="gv-message-value">${message}</span>
            </div>`
}
