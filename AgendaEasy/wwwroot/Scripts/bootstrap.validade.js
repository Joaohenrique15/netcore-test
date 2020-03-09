$.validator.setDefaults({
    //Adicionando uma classe em todos as tags informada no .find()
   

    highlight: function (element) {

        $(element)
            .closest('.form-group')
            .find('input,label,select,textarea,span')
            .addClass('is-invalid')
    },
    unhighlight: function (element) {
        $(element)
            .closest('.form-group')
            .find('input,label,select,textarea,span')
            .removeClass('is-invalid')
    },

})