import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/communications/repositories/species_repository.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/players/species.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';
import 'package:stacked_services/stacked_services.dart';

@injectable
class SpeciesSelectionViewModel extends FutureViewModel<List<Species>> {
  NavigationService _navigationService;

  SpeciesRepository _speciesRepository;

  List<Species> _species;
  List<Species> get species => _species;
  set species(List<Species> val) {
    _species = val;
    notifyListeners();
  }

  Species _selectedSpecies;
  Species get selectedSpecies => _selectedSpecies;
  set selectedSpecies(Species val) {
    _selectedSpecies = val;
    _playerSpecies.speciesId = val?.id;
    notifyListeners();
  }

  bool get isNextButtonEnabled =>
      _playerSpecies.empireName != null &&
      _playerSpecies.empireName != '' &&
      _playerSpecies.speciesId != null;

  AddPlayerSpeciesRequest _playerSpecies;

  TextEditingController empireNameController;

  SpeciesSelectionViewModel(this._navigationService, this._speciesRepository) {
    empireNameController = new TextEditingController();
    empireNameController.addListener(() {
      _playerSpecies.empireName = empireNameController.text;
      notifyListeners();
    });

    _playerSpecies = new AddPlayerSpeciesRequest();
  }

  @override
  Future<List<Species>> futureToRun() => _getAllSpeciesAsync();

  Future<List<Species>> _getAllSpeciesAsync() async {
    var response = await _speciesRepository.getAllAsync();

    if (response.hasError) {
      throw Exception('There happened an error');
    }

    species = response.data;

    return response.data;
  }

  Future<ImageProvider> getImageAsync(Guid speciesId) async {
    var response = await _speciesRepository.getImageAsync(speciesId: speciesId);

    if (response.hasError) {
      throw Exception('Failed to load species image $speciesId');
    }

    return response.data;
  }

  void showPerkSelectionView() {
    _navigationService.navigateTo(RoutePaths.PerkSelectionRoute,
        arguments: _playerSpecies);
  }
}
