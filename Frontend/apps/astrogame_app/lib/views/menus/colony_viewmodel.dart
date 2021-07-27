import 'package:astrogame_app/communications/repositories/stellar_object_repository.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:flutter/widgets.dart';

import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ColonyViewModel extends FutureViewModel {
  SelectedColonizedStellarObjectProvider _selectedStellarObjectProvider;
  StellarObjectRepository _stellarObjectRepository;
  AssetImageProvider _assetImageProvider;

  ColonizedStellarObject? colonizedStellarObject;

  ColonyViewModel(
    this._selectedStellarObjectProvider,
    this._stellarObjectRepository,
    this._assetImageProvider,
    @factoryParam this.colonizedStellarObject,
  ) : assert(colonizedStellarObject != null) {
    print(colonizedStellarObject);
  }

  bool get isSelected =>
      _selectedStellarObjectProvider.getSelectedObject() ==
      colonizedStellarObject;

  StellarObject? _stellarObject;
  StellarObject? get stellarObject => _stellarObject;
  set stellarObject(StellarObject? val) {
    _stellarObject = val;
    notifyListeners();
  }

  ImageProvider _stellarObjectImage =
      AssetImage('assets/images/stellar_objects/planet_continental_1.png');
  ImageProvider get stellarObjectImage => _stellarObjectImage;
  set stellarObjectImage(ImageProvider val) {
    _stellarObjectImage = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    stellarObject =
        await fetchStellarObject(colonizedStellarObject!.stellarObjectId);
    stellarObjectImage =
        await getStellarObjectImageAsync(stellarObject!.assetName);
  }

  Future<ImageProvider> getStellarObjectImageAsync(String assetName) async {
    return _assetImageProvider.get(assetName, ImageScope.stellarObject);
  }

  Future<StellarObject> fetchStellarObject(Guid id) async {
    var response = await _stellarObjectRepository.getAsync(id);

    if (response.hasError) {
      throw new Exception(response.error);
    }

    if (response.data == null) {
      throw Exception('StellarObject cannot be null');
    }

    return response.data!;
  }
}
