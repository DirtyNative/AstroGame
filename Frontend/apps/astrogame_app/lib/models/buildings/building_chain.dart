import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

import 'building_construction.dart';

part 'building_chain.g.dart';

@GuidConverter()
@JsonSerializable()
class BuildingChain {
  late Guid id;
  late Guid playerId;
  late int chainLength;

  List<BuildingConstruction> buildingUpgrades = [];

  BuildingChain();

  factory BuildingChain.fromJson(Map<String, dynamic> json) =>
      _$BuildingChainFromJson(json);
  Map<String, dynamic> toJson() => _$BuildingChainToJson(this);
}
