import 'package:astrogame_app/models/technologies/technology_upgrade.dart';
import 'package:json_annotation/json_annotation.dart';
import 'package:astrogame_app/models/technologies/stellar_object_dependent_technology_upgrade.dart';
import 'package:astrogame_app/models/technologies/player_dependent_technology_upgrade.dart';

class TechnologyUpgradeConverter
    implements JsonConverter<TechnologyUpgrade, Map<String, dynamic>> {
  const TechnologyUpgradeConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'StellarObjectDependentTechnologyUpgrade') {
      return StellarObjectDependentTechnologyUpgrade.fromJson(json);
    } else if (type.value == 'PlayerDependentTechnologyUpgrade') {
      return PlayerDependentTechnologyUpgrade.fromJson(json);
    }

    throw new UnimplementedError('Technology upgrade is not yet implemented');
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}
