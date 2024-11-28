function ViewModel() {
    let self = this;
    self.coverType = ko.observableArray([]);

    self.loadCoverType = function () {
        fetch('/Admin/CoverType/GetCoverType')
            .then(response => response.json())
            .then(data => {
                let mappedCoverType = ko.mapping.fromJS(data);
                self.coverType(mappedCoverType());
            })
            .catch(error => console.error('Error loading covertype:', error));
    };

    self.loadCoverType();
}

ko.applyBindings(new ViewModel());
