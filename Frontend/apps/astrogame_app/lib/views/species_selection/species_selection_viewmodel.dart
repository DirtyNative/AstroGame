import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/communications/repositories/species_repository.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';
import 'package:astrogame_app/models/players/species.dart';
import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:flutter/cupertino.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class SpeciesSelectionViewModel extends FutureViewModel {
  NavigationWrapper _navigationService;

  SpeciesRepository _speciesRepository;
  AssetImageProvider _assetImageProvider;

  late TextEditingController empireNameController;

  SpeciesSelectionViewModel(
    this._navigationService,
    this._speciesRepository,
    this._assetImageProvider,
  ) {
    empireNameController = new TextEditingController();
    empireNameController.addListener(() {
      empireName = empireNameController.text;
      notifyListeners();
    });
  }

  late List<Species> _species;
  List<Species> get species => _species;
  set species(List<Species> val) {
    _species = val;
    notifyListeners();
  }

  Species? _selectedSpecies;
  Species? get selectedSpecies => _selectedSpecies;
  set selectedSpecies(Species? val) {
    _selectedSpecies = val;
    notifyListeners();
  }

  String _empireName = '';
  String get empireName => _empireName;
  set empireName(String val) {
    _empireName = val;
    notifyListeners();
  }

  bool get isNextButtonEnabled => empireName != '';

  @override
  Future futureToRun() async {
    species = await _getAllSpeciesAsync();
  }

  Future<List<Species>> _getAllSpeciesAsync() async {
    var response = await _speciesRepository.getAllAsync();

    if (response.hasError) {
      throw Exception('There happened an error');
    }

    return response.data ?? [];
  }

  Future<ImageProvider> getImageAsync(String assetName) async {
    return await _assetImageProvider.get(assetName, ImageScope.species);
  }

  void showPerkSelectionView() {
    if (selectedSpecies == null) {
      return;
    }

    var playerSpecies = new AddPlayerSpeciesRequest(selectedSpecies!.id,
        empireNameController.text, PlanetType.continental, []);

    _navigationService.navigateTo(RoutePaths.PerkSelectionRoute,
        arguments: playerSpecies);
  }
}
