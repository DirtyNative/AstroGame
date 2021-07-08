// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'fixed_building.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

FixedBuilding _$FixedBuildingFromJson(Map<String, dynamic> json) {
  return FixedBuilding()
    ..id = const GuidConverter().fromJson(json['id'] as String)
    ..name = json['name'] as String
    ..description = json['description'] as String
    ..assetName = json['assetName'] as String
    ..order = json['order'] as int
    ..neededConditions = (json['neededConditions'] as List)
        ?.map((e) =>
            e == null ? null : Condition.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..conditionFor = (json['conditionFor'] as List)
        ?.map((e) =>
            e == null ? null : Condition.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..technologyCosts = (json['technologyCosts'] as List)
        ?.map((e) => e == null
            ? null
            : TechnologyCost.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..buildingType =
        _$enumDecodeNullable(_$BuildingTypeEnumMap, json['buildingType'])
    ..buildableOn =
        _$enumDecodeNullable(_$StellarObjectTypeEnumMap, json['buildableOn'])
    ..inputResources = (json['inputResources'] as List)
        ?.map((e) => e == null
            ? null
            : InputResource.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..outputResource = (json['outputResource'] as List)
        ?.map((e) => e == null
            ? null
            : OutputResource.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$FixedBuildingToJson(FixedBuilding instance) =>
    <String, dynamic>{
      'id': const GuidConverter().toJson(instance.id),
      'name': instance.name,
      'description': instance.description,
      'assetName': instance.assetName,
      'order': instance.order,
      'neededConditions': instance.neededConditions,
      'conditionFor': instance.conditionFor,
      'technologyCosts': instance.technologyCosts,
      'buildingType': _$BuildingTypeEnumMap[instance.buildingType],
      'buildableOn': _$StellarObjectTypeEnumMap[instance.buildableOn],
      'inputResources': instance.inputResources,
      'outputResource': instance.outputResource,
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

const _$BuildingTypeEnumMap = {
  BuildingType.civilBuilding: 0,
  BuildingType.conveyorBuilding: 1,
  BuildingType.manufacturingFacilityBuilding: 2,
  BuildingType.refineryBuilding: 3,
  BuildingType.researchLaboratoryBuilding: 4,
  BuildingType.storageBuilding: 5,
};

const _$StellarObjectTypeEnumMap = {
  StellarObjectType.star: 0,
  StellarObjectType.blackHole: 1,
  StellarObjectType.planet: 2,
  StellarObjectType.moon: 3,
  StellarObjectType.asteroid: 4,
  StellarObjectType.asteroidBelt: 5,
};
