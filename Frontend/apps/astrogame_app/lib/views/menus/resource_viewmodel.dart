import 'dart:async';

import 'package:astrogame_app/communications/repositories/stored_resource_repository.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ResourceViewModel extends FutureViewModel {
  StoredResourceRepository _storedResourceRepository;

  ResourceProvider _resourceProvider;

  Timer _timer;

  List<StoredResource> _storedResources = [];
  List<StoredResource> get storedResources => _storedResources;
  set storedResources(List<StoredResource> val) {
    _storedResources = val;
    notifyListeners();
  }

  ResourceViewModel(this._storedResourceRepository, this._resourceProvider) {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      for (int index = 0; index < storedResources.length; index++) {
        storedResources[index].amount +=
            storedResources[index].hourlyAmount * (1 / 3600);
      }

      notifyListeners();
    });
  }

  @override
  Future futureToRun() => _fetchStoredResourcesAsync();

  Resource getResource(Guid resourceId) => _resourceProvider
      .getResources()
      .firstWhere((element) => element.id == resourceId);

  Future _fetchStoredResourcesAsync() async {
    var response =
        await _storedResourceRepository.getOnCurrentStellarObjectAsync();

    if (response.hasError) {
      storedResources.clear();
      return;
    }

    storedResources = response.data;
  }

  @override
  void dispose() {
    _timer?.cancel();
    super.dispose();
  }
}
