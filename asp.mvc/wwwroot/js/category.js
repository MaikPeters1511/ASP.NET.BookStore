function ViewModel() {
    let self = this
    self.categories = ko.observableArray([])

    self.loadCategories = function () {
        $.getJSON('/Category/GetCategories', function (data) {
            let mappedCategories = ko.mapping.fromJS(data)
            self.categories(mappedCategories())
        });
    };

    self.loadCategories()
}

ko.applyBindings(new ViewModel())