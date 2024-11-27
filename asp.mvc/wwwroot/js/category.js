function ViewModel() {
    let self = this;
    self.categories = ko.observableArray([]);

    self.loadCategories = function () {
        fetch('/Admin/Category/GetCategories')
            .then(response => response.json())
            .then(data => {
                let mappedCategories = ko.mapping.fromJS(data);
                self.categories(mappedCategories());
            })
            .catch(error => console.error('Error loading categories:', error));
    };

    self.loadCategories();
}

ko.applyBindings(new ViewModel());
