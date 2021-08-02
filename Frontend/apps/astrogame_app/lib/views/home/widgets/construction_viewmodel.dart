import 'package:astrogame_app/communications/repositories/stellar_object_repository.dart';
import 'package:astrogame_app/models/technologies/stellar_object_dependent_technology_upgrade.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ConstructionViewModel extends FutureViewModel {
  StellarObjectRepository _stellarObjectRepository;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;
  AssetImageProvider _assetImageProvider;

  ConstructionViewModel(
    this._stellarObjectRepository,
    this._selectedColonizedStellarObjectProvider,
    this._assetImageProvider,
    @factoryParam this._buildingConstruction,
  ) : assert(_buildingConstruction != null);

  StellarObjectDependentTechnologyUpgrade? _buildingConstruction;
  StellarObjectDependentTechnologyUpgrade? get buildingConstruction =>
      _buildingConstruction;
  set buildingConstruction(StellarObjectDependentTechnologyUpgrade? val) {
    _buildingConstruction = val;
    notifyListeners();
  }

  late StellarObject _stellarObject;
  StellarObject get stellarObject => _stellarObject;
  set stellarObject(StellarObject val) {
    _stellarObject = val;
    notifyListeners();
  }

  late ImageProvider _stellarObjectImage;
  ImageProvider get stellarObjectImage => _stellarObjectImage;
  set stellarObjectImage(ImageProvider val) {
    _stellarObjectImage = val;
    notifyListeners();
  }

  Future<ImageProvider> _fetchStellarObjectImageAsync() async {
    return await _assetImageProvider.get(
        stellarObject.assetName, ImageScope.stellarObject);
  }

  Future<StellarObject> _fetchStellarObject() async {
    var selectedStellarObject =
        _selectedColonizedStellarObjectProvider.getSelectedObject();

    var response = await _stellarObjectRepository
        .getAsync(selectedStellarObject!.stellarObjectId);

    if (response.hasError) {
      throw new Exception(response.error);
    }

    return response.data!;
  }

  @override
  Future futureToRun() async {
    stellarObject = await _fetchStellarObject();
    stellarObjectImage = await _fetchStellarObjectImageAsync();
  }
}
