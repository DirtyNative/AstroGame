import 'package:astrogame_app/communications/repositories/solar_system_repository.dart';
import 'package:astrogame_app/executers/executer_result.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:injectable/injectable.dart';

@injectable
class FetchSolarSystemExecuter {
  SolarSystemRepository _solarSystemRepository;

  DialogHelper _dialogHelper;

  FetchSolarSystemExecuter(
    this._dialogHelper,
    this._solarSystemRepository,
  );

  Future<ExecuterResultT1<SolarSystem>> fetchSolarSystemByNumberAsync(
      int number) async {
    _dialogHelper.showLoadingIndicator();

    var response =
        await _solarSystemRepository.getBySystemNumberRecursiveAsync(number);

    // If there happened an error
    if (response.hasError) {
      // TODO: show error dialog;
      return ExecuterResultT1.error();
    }

    _dialogHelper.dismissDialog();

    return ExecuterResultT1.success(response.data);
  }
}
