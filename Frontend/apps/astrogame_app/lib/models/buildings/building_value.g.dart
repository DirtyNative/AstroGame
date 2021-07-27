// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'building_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

BuildingValue _$BuildingValueFromJson(Map<String, dynamic> json) {
  return BuildingValue()
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..level = json['level'] as int
    ..technologyCosts = (json['technologyCosts'] as List<dynamic>)
        .map((e) => ResourceAmount.fromJson(e as Map<String, dynamic>))
        .toList()
    ..consumptions = (json['consumptions'] as List<dynamic>)
        .map((e) => ResourceAmount.fromJson(e as Map<String, dynamic>))
        .toList()
    ..productions = (json['productions'] as List<dynamic>)
        .map((e) => ResourceAmount.fromJson(e as Map<String, dynamic>))
        .toList();
}

Map<String, dynamic> _$BuildingValueToJson(BuildingValue instance) =>
    <String, dynamic>{
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'level': instance.level,
      'technologyCosts': instance.technologyCosts,
      'consumptions': instance.consumptions,
      'productions': instance.productions,
    };
