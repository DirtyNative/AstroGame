import 'package:astrogame_app/communications/repositories/technology_repository.dart';
import 'package:astrogame_app/events/server_events/buildings/technology_upgrade_started_event.dart';
import 'package:astrogame_app/executers/executer_result.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/providers/stored_resource_provider.dart';
import 'package:astrogame_app/providers/technology_upgrades_provider.dart';
import 'package:astrogame_app/services/event_service.dart';

import 'package:injectable/injectable.dart';

@injectable
class UpgradeTechnologyExecuter {
  EventService _eventService;

  TechnologyRepository _technologyRepository;
  TechnologyUpgradesProvider _technologyUpgradesProvider;
  StoredResourceProvider _storedResourceProvider;

  DialogHelper _dialogHelper;

  UpgradeTechnologyExecuter(
    this._eventService,
    this._dialogHelper,
    this._technologyRepository,
    this._technologyUpgradesProvider,
    this._storedResourceProvider,
  );

  Future<ExecuterResult> upgradeTechnologyAsync(
    Guid technologyId,
  ) async {
    _dialogHelper.showLoadingIndicator();

    var response = await _technologyRepository.upgradeAsync(technologyId);

    // If there happened an error
    if (response.hasError) {
      // TODO: show error dialog;
      _dialogHelper.dismissDialog();
      return ExecuterResult.error();
    }

// TODO: Check if this is needed because the server needs too long to send the event
    //await _technologyUpgradesProvider.updateAsync();
    //await _storedResourceProvider.updateAsync();

    // Raise an event so that the ui can update
    _eventService.fire(new TechnologyUpgradeStartedEvent());

    _dialogHelper.dismissDialog();
    return ExecuterResult.success();
  }
}
