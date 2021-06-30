import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/models/buildings/building_value.dart';
import 'package:astrogame_app/models/buildings/built_building.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/resource_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingDetailViewModel extends FutureViewModel {
  BuildingRepository _buildingRepository;
  ResourceProvider _resourceProvider;
  BuildingImageProvider _buildingImageProvider;

  Building building;
  BuiltBuilding builtBuilding;

  BuildingDetailViewModel(
    this._buildingRepository,
    this._resourceProvider,
    this._buildingImageProvider,
    @factoryParam this.building,
    @factoryParam this.builtBuilding,
  );

  List<BuildingValue> _buildingValues;
  List<BuildingValue> get buildingValues => _buildingValues;
  set buildingValues(List<BuildingValue> val) {
    _buildingValues = val;
    notifyListeners();
  }

  List<Resource> _resources;
  List<Resource> get resources => _resources;
  set resources(List<Resource> val) {
    _resources = val;
    notifyListeners();
  }

  ImageProvider _buildingImage;
  ImageProvider get buildingImage => _buildingImage;
  set buildingImage(ImageProvider val) {
    _buildingImage = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    resources = await _fetchResourcesAsync();
    buildingValues = await _fetchBuildingValues();
    buildingImage = await _fetchImageAsync(building.assetName);
  }

  Future<List<Resource>> _fetchResourcesAsync() async {
    return await _resourceProvider.getAsync();
  }

  Future<List<BuildingValue>> _fetchBuildingValues() async {
    var response = await _buildingRepository.getValuesAsync(building.id, builtBuilding?.level ?? 1, 10);

    if (response.hasError) {
      throw Exception(response.error);
    }

    return response.data;
  }

  Future<ImageProvider> _fetchImageAsync(String assetName) async {
    return await _buildingImageProvider.get(assetName);
  }
}
