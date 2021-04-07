// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_chain.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuildingChain _$BuildingChainFromJson(Map<String, dynamic> json) {
  return BuildingChain()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..chainLength = json['chainLength'] as int
    ..buildingUpgrades = (json['buildingUpgrades'] as List)
        ?.map((e) => e == null
            ? null
            : BuildingConstruction.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$BuildingChainToJson(BuildingChain instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'chainLength': instance.chainLength,
      'buildingUpgrades': instance.buildingUpgrades,
    };
