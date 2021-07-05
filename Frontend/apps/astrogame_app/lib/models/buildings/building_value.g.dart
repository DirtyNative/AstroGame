// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuildingValue _$BuildingValueFromJson(Map<String, dynamic> json) {
  return BuildingValue()
    ..level = json['level'] as int
    ..technologyCosts = (json['technologyCosts'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..buildingId = const GuidConverter().fromJson(json['buildingId'] as String)
    ..buildingConsumptions = (json['buildingConsumptions'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..buildingProductions = (json['buildingProductions'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$BuildingValueToJson(BuildingValue instance) =>
    <String, dynamic>{
      'level': instance.level,
      'technologyCosts': instance.technologyCosts,
      'buildingId': const GuidConverter().toJson(instance.buildingId),
      'buildingConsumptions': instance.buildingConsumptions,
      'buildingProductions': instance.buildingProductions,
    };
