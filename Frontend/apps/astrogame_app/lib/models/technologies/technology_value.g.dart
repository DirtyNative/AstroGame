// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'technology_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TechnologyValue _$TechnologyValueFromJson(Map<String, dynamic> json) {
  return TechnologyValue()
    ..level = json['level'] as int
    ..technologyCosts = (json['technologyCosts'] as List)
        ?.map((e) => e == null
            ? null
            : ResourceAmount.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$TechnologyValueToJson(TechnologyValue instance) =>
    <String, dynamic>{
      'level': instance.level,
      'technologyCosts': instance.technologyCosts,
    };
