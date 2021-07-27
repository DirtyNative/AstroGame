import 'package:astrogame_app/communications/dtos/add_player_species_perk_request.dart';
import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/communications/repositories/perk_repository.dart';
import 'package:astrogame_app/executers/set_players_species_executer.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';
import 'package:astrogame_app/models/players/perk.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class PerkSelectionViewModel extends FutureViewModel {
  PerkRepository _perkRepository;
  SetPlayersSpeciesExecuter _setPlayersSpeciesExecuter;

  AddPlayerSpeciesRequest? _playerSpecies;
  static const int countMaxPerks = 3;

  PerkSelectionViewModel(
    this._perkRepository,
    this._setPlayersSpeciesExecuter,
    @factoryParam this._playerSpecies,
  ) : assert(_playerSpecies != null);

  List<Perk> _perks = [];
  List<Perk> get perks => _perks;

  int get countPerks => _perks.length;

  int get countSelectedItems => _playerSpecies!.perks.length;

  PlanetType get selectedPlanetType => _playerSpecies!.preferredPlanetType;
  set selectedPlanetType(PlanetType val) {
    _playerSpecies!.preferredPlanetType = val;
    notifyListeners();
  }

  bool get isButtonEnabled => _playerSpecies!.perks.length != 0;

  @override
  Future futureToRun() async {
    _perks = await _getAllPerksAsync();
  }

  Future<List<Perk>> _getAllPerksAsync() async {
    var response = await _perkRepository.getAllAsync();

    if (response.hasError) {
      throw Exception('There happened an error');
    }

    return response.data ?? [];
  }

  bool isPerkSelected(int index) {
    if (perks.length == 0 || _playerSpecies!.perks.length == 0) {
      return false;
    }

    return _playerSpecies!.perks
        .any((element) => element.perkId == _perks[index].id);
  }

  void trySetSelected(int index) {
    // If the item is already selected, just unselect it
    if (_playerSpecies!.perks
        .any((element) => element.perkId == _perks[index].id)) {
      _playerSpecies!.perks
          .removeWhere((element) => element.perkId == _perks[index].id);

      notifyListeners();
      return;
    }

    if (countSelectedItems >= countMaxPerks) {
      return;
    }

    _playerSpecies!.perks.add(
      new AddPlayerSpeciesPerkRequest(_perks[index].id),
    );

    notifyListeners();
  }

  Future saveSpecies() async {
    await _setPlayersSpeciesExecuter.addPlayerSpeciesAsync(_playerSpecies!);
  }
}
