// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'research_value.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ResearchValue _$ResearchValueFromJson(Map<String, dynamic> json) {
  return ResearchValue()
    ..technologyId =
        const GuidConverter().fromJson(json['technologyId'] as String)
    ..level = json['level'] as int
    ..technologyCosts = (json['technologyCosts'] as List<dynamic>)
        .map((e) => ResourceAmount.fromJson(e as Map<String, dynamic>))
        .toList();
}

Map<String, dynamic> _$ResearchValueToJson(ResearchValue instance) =>
    <String, dynamic>{
      'technologyId': const GuidConverter().toJson(instance.technologyId),
      'level': instance.level,
      'technologyCosts': instance.technologyCosts,
    };
