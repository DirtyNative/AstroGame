// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'studied_research.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StudiedResearch _$StudiedResearchFromJson(Map<String, dynamic> json) {
  return StudiedResearch()
    ..neededConditions = (json['neededConditions'] as List)
        ?.map((e) =>
            e == null ? null : Condition.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..conditionFor = (json['conditionFor'] as List)
        ?.map((e) =>
            e == null ? null : Condition.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..name = json['name'] as String
    ..description = json['description'] as String
    ..order = json['order'] as int
    ..researchType =
        _$enumDecodeNullable(_$ResearchTypeEnumMap, json['researchType'])
    ..assetName = json['assetName'] as String
    ..buildingTimeMultiplier =
        (json['buildingTimeMultiplier'] as num)?.toDouble()
    ..buildingCostMultiplier =
        (json['buildingCostMultiplier'] as num)?.toDouble()
    ..buildingProductionMultiplier =
        (json['buildingProductionMultiplier'] as num)?.toDouble()
    ..buildingConsumptionMultiplier =
        (json['buildingConsumptionMultiplier'] as num)?.toDouble()
    ..structuralIntegrityMultiplier =
        (json['structuralIntegrityMultiplier'] as num)?.toDouble()
    ..shieldPowerMultiplier = (json['shieldPowerMultiplier'] as num)?.toDouble()
    ..weaponPowerMultiplier = (json['weaponPowerMultiplier'] as num)?.toDouble()
    ..cargoCapacityMultiplier =
        (json['cargoCapacityMultiplier'] as num)?.toDouble()
    ..stellarSpeedMultiplier =
        (json['stellarSpeedMultiplier'] as num)?.toDouble()
    ..interstellarSpeedMultiplier =
        (json['interstellarSpeedMultiplier'] as num)?.toDouble()
    ..fuelConsumptionMultiplier =
        (json['fuelConsumptionMultiplier'] as num)?.toDouble()
    ..researchCosts = (json['researchCosts'] as List)
        ?.map((e) =>
            e == null ? null : ResearchCost.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..researchId = const GuidConverter().fromJson(json['researchId'] as String)
    ..playerId = const GuidConverter().fromJson(json['playerId'] as String)
    ..level = json['level'] as int;
}

Map<String, dynamic> _$StudiedResearchToJson(StudiedResearch instance) =>
    <String, dynamic>{
      'neededConditions': instance.neededConditions,
      'conditionFor': instance.conditionFor,
      'name': instance.name,
      'description': instance.description,
      'order': instance.order,
      'researchType': _$ResearchTypeEnumMap[instance.researchType],
      'assetName': instance.assetName,
      'buildingTimeMultiplier': instance.buildingTimeMultiplier,
      'buildingCostMultiplier': instance.buildingCostMultiplier,
      'buildingProductionMultiplier': instance.buildingProductionMultiplier,
      'buildingConsumptionMultiplier': instance.buildingConsumptionMultiplier,
      'structuralIntegrityMultiplier': instance.structuralIntegrityMultiplier,
      'shieldPowerMultiplier': instance.shieldPowerMultiplier,
      'weaponPowerMultiplier': instance.weaponPowerMultiplier,
      'cargoCapacityMultiplier': instance.cargoCapacityMultiplier,
      'stellarSpeedMultiplier': instance.stellarSpeedMultiplier,
      'interstellarSpeedMultiplier': instance.interstellarSpeedMultiplier,
      'fuelConsumptionMultiplier': instance.fuelConsumptionMultiplier,
      'researchCosts': instance.researchCosts,
      'id': const GuidConverter().toJson(instance.id),
      'researchId': const GuidConverter().toJson(instance.researchId),
      'playerId': const GuidConverter().toJson(instance.playerId),
      'level': instance.level,
    };

T _$enumDecode<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    throw ArgumentError('A value must be provided. Supported values: '
        '${enumValues.values.join(', ')}');
  }

  final value = enumValues.entries
      .singleWhere((e) => e.value == source, orElse: () => null)
      ?.key;

  if (value == null && unknownValue == null) {
    throw ArgumentError('`$source` is not one of the supported values: '
        '${enumValues.values.join(', ')}');
  }
  return value ?? unknownValue;
}

T _$enumDecodeNullable<T>(
  Map<T, dynamic> enumValues,
  dynamic source, {
  T unknownValue,
}) {
  if (source == null) {
    return null;
  }
  return _$enumDecode<T>(enumValues, source, unknownValue: unknownValue);
}

const _$ResearchTypeEnumMap = {
  ResearchType.physics: 0,
  ResearchType.engineering: 1,
  ResearchType.biology: 2,
  ResearchType.social: 3,
  ResearchType.astronomy: 4,
  ResearchType.industry: 5,
  ResearchType.military: 6,
  ResearchType.newWorlds: 7,
};
